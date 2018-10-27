using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Medico;
using Logica.Clases.Medico;
using Logica.Clases.Administrador;

public partial class View_Medico_InsertarEliminarActualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        LB_Mensaje.Visible = false;
        Response.Cache.SetNoStore();

        if (Session["usuario"] == null)
        {
            Response.Redirect("~/View/Login.aspx");
        }
        if (!IsPostBack)
        {

            if (Session["Accion"] != null)
            {
                if (Session["Accion"].ToString().Equals("Insertar"))
                {
                    L_Titulo.Text = "Agregar nuevo medico";
                    adecuarParaInsertar();
                }
                else if (Session["Accion"].ToString().Equals("Actualizar"))
                {
                    L_Titulo.Text = "Actualizar Información";
                    adecuarParaActualizar();
                }
                else if (Session["Accion"].ToString().Equals("Eliminar"))
                {
                }
            }

        }
    }

    protected void adecuarParaInsertar()
    {
        cargarEspecialidades();
        cargarConsultoriosDisponibles();
        BTN_Accion.Text = "Agregar";
    }

    protected void adecuarParaActualizar()
    {
        string identificacion = Session["identificacion_medico"].ToString();

        LMedico lMedico = new LMedico();
        LConsultorio lConsultorio = new LConsultorio();

        EMedico eMedico = lMedico.adecuarParaActualizar(identificacion);

        DDL_Tipo_Documento.SelectedIndex = eMedico.TipoIdentificacion;
        TB_Numero_Documento.Text = eMedico.Identificacion; ;
        TB_Nombre.Text = eMedico.Nombre;
        TB_Apellido.Text = eMedico.Apellido;
        TB_Fecha_Nacimiento.TextMode = TextBoxMode.Date;
        TB_Fecha_Nacimiento.Text = DateTime.Parse(eMedico.FechaNacimiento).ToString("yyyy-MM-dd");

        cargarEspecialidades();

        foreach (ListItem listItem in DDL_Especialidad.Items)
        {
            listItem.Selected = listItem.Text == eMedico.EEspecialidad.Nombre;
        }

        DataRow drConsultorioMedico = lConsultorio.obtenerConsultorio(eMedico.Consultorio);

        Session["consultorio"] = drConsultorioMedico["id"].ToString();
        ListItem consultorioMedico = new ListItem(drConsultorioMedico["nombre_consultorio"].ToString(), drConsultorioMedico["id"].ToString());
        consultorioMedico.Selected = true;
        DDL_Consultorio.Items.Add(consultorioMedico);

        cargarConsultoriosDisponibles();

        TB_Correo.Text = eMedico.Correo;
        TB_Contrasena.Attributes.Add("value", eMedico.Password);
        TB_Repetir_Contrasena.Attributes.Add("value", eMedico.Password);
        BTN_Accion.Text = "Actualizar";

        if (Session["usuario"].GetType() == new EMedico().GetType())
        {
            DDL_Tipo_Documento.Enabled = false;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Enabled = false;
            TB_Apellido.Enabled = false;
            TB_Fecha_Nacimiento.Enabled = false;
            DDL_Especialidad.Enabled = false;
            DDL_Consultorio.Enabled = false;
            TB_Correo.Enabled = false;
        }

    }

    protected void cargarEspecialidades()
    {
        LEspecialidad lEspecialidad = new LEspecialidad();
        DDL_Especialidad.Items.Add(new ListItem("Ninguno", "0"));
        ListItem listItem = lEspecialidad.cargarEspecialidades();

        DDL_Especialidad.Items.Add(listItem);
    }

    protected void cargarConsultoriosDisponibles()
    {
        LConsultorio lConsultorio = new LConsultorio();
        ListItem listItem = new ListItem();
        listItem = lConsultorio.cargarConsultoriosDisponibles();
        DDL_Consultorio.Items.Add(listItem);
    }

    protected Boolean validarDatos()
    {
        string mensaje = "";
        LMedico lMedico = new LMedico();
        EMedico eMedico = new EMedico();

        eMedico.Identificacion = TB_Numero_Documento.Text.Trim();
        eMedico.Nombre = TB_Nombre.Text.Trim();
        eMedico.Apellido = TB_Apellido.Text.Trim();
        eMedico.FechaNacimiento = TB_Fecha_Nacimiento.Text;
        eMedico.Correo = TB_Correo.Text.Trim();
        eMedico.Password = TB_Contrasena.Text.Trim();

        try
        {
            lMedico.validarTipoDocumento(DDL_Tipo_Documento.SelectedIndex);
        }
        catch (Exception ex)
        {
            mensaje += ex.Message.ToString();
        }

        try
        {
            lMedico.validarNumeroDocumentoVacio(TB_Numero_Documento.Text.Trim());
            try
            {
                lMedico.validarnueroIdentificacion(TB_Numero_Documento.Text.Trim(), BTN_Accion.Text, Session["identificacion_medico"]);
            }
            catch (Exception ex)
            {
                mensaje += ex.Message.ToString();
            }
        }
        catch (Exception ex)
        {
            mensaje += ex.Message.ToString();
        }

        try
        {
            lMedico.validarDDLEspecialidad(DDL_Especialidad.SelectedItem.Text);
        }
        catch (Exception ex)
        {
            mensaje += ex.Message.ToString();
        }

        try
        {
            lMedico.validarDatos(eMedico, BTN_Accion.Text, Session["identificacion_medico"], TB_Repetir_Contrasena.Text.Trim());
        }
        catch (Exception ex)
        {
            mensaje += ex.Message.ToString();
            LB_Mensaje.Text = "Tenga en cuenta:<br/>" + mensaje;
            LB_Mensaje.Visible = true;
            return false;
        }

        return true;
    }

    protected EMedico recolectarDatos()
    {
        EMedico eMedico = new EMedico();
        DBConsultorio dBConsultorio = new DBConsultorio();
        eMedico.TipoIdentificacion = int.Parse(DDL_Tipo_Documento.SelectedItem.Value);
        eMedico.Identificacion = TB_Numero_Documento.Text.Trim();
        eMedico.Nombre = TB_Nombre.Text.Trim();
        eMedico.Apellido = TB_Apellido.Text.Trim();
        eMedico.FechaNacimiento = TB_Fecha_Nacimiento.Text;
        eMedico.TipoEspecialidad = int.Parse(DDL_Especialidad.SelectedItem.Value);
        eMedico.Consultorio = int.Parse(DDL_Consultorio.SelectedItem.Value);
        eMedico.Correo = TB_Correo.Text.Trim();
        eMedico.Password = TB_Contrasena.Text;
        eMedico.Session = Session.SessionID;
        return eMedico;
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;

        try
        {
            if (validarDatos())
            {
                EMedico eMedico = recolectarDatos();
                LMedico lMedico = new LMedico();
                lMedico.guardarMedico(eMedico, btnAccion.Text, Session["consultorio"], Session.SessionID);
                Session["Accion"] = null;
                Response.Redirect(Session["PaginaAnterior"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
    }
}