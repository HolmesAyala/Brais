using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        if (Session["Accion"] != null)
        {
            if (Session["Accion"].ToString().Equals("Insertar"))
            {
                L_Titulo.Text = "Agregar nuevo usuario";
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
            Session["Accion"] = null;
            Session["identificacion"] = null;
        }
    }

    protected void adecuarParaInsertar()
    {
        BTN_Accion.Text = "Agregar";
    }

    protected void adecuarParaActualizar()
    {

        if (Session["usuario"].GetType() == new EMedico().GetType())
        {
            string identificacion = Session["identificacion_medico"].ToString();

            DBMedico dBMedico = new DBMedico();

            DataTable dtMedico = dBMedico.obtenerMedico(identificacion);

            EMedico eMedico = Funcion.dataTableToEMedico(dtMedico);

            DDL_Tipo_Documento.SelectedIndex = eMedico.TipoIdentificacion;
            DDL_Tipo_Documento.Enabled = false;
            TB_Numero_Documento.Text = eMedico.Identificacion; ;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Text = eMedico.Nombre;
            TB_Nombre.Enabled = false;
            TB_Apellido.Text = eMedico.Apellido;
            TB_Apellido.Enabled = false;
            TB_Fecha_Nacimiento.TextMode = TextBoxMode.Date;
            TB_Fecha_Nacimiento.Text = DateTime.Parse(eMedico.FechaNacimiento).ToString("yyyy-MM-dd");
            TB_Fecha_Nacimiento.Enabled = false;
            DDL_Especialidad.SelectedIndex = eMedico.TipoEspecialidad;
            adecuarConsultorio(eMedico.Consultorio);
            TB_Correo.Text = eMedico.Correo;
            TB_Contrasena.Attributes.Add("value", eMedico.Password);
            TB_Repetir_Contrasena.Attributes.Add("value", eMedico.Password);
            BTN_Accion.Text = "Actualizar";

        }
        else if (Session["usuario"].GetType() == new EUsuario().GetType())
        {
            string identificacion = Session["identificacion"].ToString();

            DBMedico dBMedico = new DBMedico();

            DataTable dtMedico = dBMedico.obtenerMedico(identificacion);

            EMedico eMedico = Funcion.dataTableToEMedico(dtMedico);

            DDL_Tipo_Documento.SelectedIndex = eMedico.TipoIdentificacion;
            TB_Numero_Documento.Text = eMedico.Identificacion; ;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Text = eMedico.Nombre;
            TB_Apellido.Text = eMedico.Apellido;
            TB_Fecha_Nacimiento.TextMode = TextBoxMode.Date;
            TB_Fecha_Nacimiento.Text = DateTime.Parse(eMedico.FechaNacimiento).ToString("yyyy-MM-dd");
            DDL_Especialidad.SelectedIndex = eMedico.TipoEspecialidad;
            adecuarConsultorio(eMedico.Consultorio);
            TB_Correo.Text = eMedico.Correo;
            TB_Contrasena.Attributes.Add("value", eMedico.Password);
            TB_Repetir_Contrasena.Attributes.Add("value", eMedico.Password);
            BTN_Accion.Text = "Actualizar";

        }

    }

    protected void adecuarConsultorio(int id_Consultorio)
    {
        DBConsultorio dBConsultorio = new DBConsultorio();
        DataTable consultorio = dBConsultorio.obtenerConsultorio(id_Consultorio);
        L_Consultorio.Visible = true;
        TB_Consultorio.Visible = true;
        TB_Consultorio.Text = consultorio.Rows[0]["nombre_consultorio"].ToString();
        TB_Consultorio.Enabled = false;
        DDL_Consultorio.SelectedIndex = 0;
        Session["consultorio"] = id_Consultorio;
    }

    protected Boolean validarDatos()
    {
        string mensaje = "";
        if (DDL_Tipo_Documento.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado un tipo de documento.<br/>";
        }
        if (TB_Numero_Documento.Text.Trim().Equals(""))
        {
            mensaje += "- El campo Numero de documento esta vacio.<br/>";
        }
        else
        {
            DBMedico dBMedico = new DBMedico();
            if (dBMedico.obtenerMedico(TB_Numero_Documento.Text.Trim()).Rows.Count > 0 && BTN_Accion.Text.Equals("Agregar"))
            {
                mensaje += "- YA EXISTE UN MÉDICO CON ESA IDENTIFICACION.<br/>";
            }
            try
            {
                int.Parse(TB_Numero_Documento.Text.Trim());
            }
            catch (Exception)
            {
                mensaje += "- El numero de documento solo debe incluir numeros.<br/>";
            }
        }

        if (TB_Nombre.Text.Trim().Equals(""))
        {
            mensaje += "- El campo nombre esta vacio.<br/>";
        }
        if (TB_Apellido.Text.Trim().Equals(""))
        {
            mensaje += "- El campo apellido esta vacio.<br/>";
        }

        if (TB_Fecha_Nacimiento.Text.Equals(""))
        {
            mensaje += "- No ha seleccionado fecha de nacimiento.<br/>";
        }
        else if (Convert.ToDateTime(TB_Fecha_Nacimiento.Text) > DateTime.Now)
        {
            mensaje += "- Su fecha de nacimiento debe <br/>  ser menor a la fecha actual.<br/>";
        }

        if (DDL_Especialidad.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado la especialidad.<br/>";
        }

        if (DDL_Consultorio.SelectedIndex == 0)
        {
            DBConsultorio dBConsultorio = new DBConsultorio();

            DataTable medico = dBConsultorio.obtenerConsultorios();

            if(TB_Consultorio.Text.ToString() == "" || TB_Consultorio.Text.ToString() == "Ninguno")
            {
                if (medico.Rows.Count == 1)
                {
                    mensaje += "- No hay consultorios disponibles.<br/>";
                }
                else if (medico.Rows.Count > 1)
                {
                    mensaje += "- No ha seleccionado el consultorio.<br/>";
                }
            }
        }

        if (TB_Correo.Text.Trim().Equals(""))
        {
            mensaje += "- El campo correo esta vacio.<br/>";
        }
        else if (!DBUsuario.validarExistenciaCorreo(TB_Correo.Text.Trim()) && BTN_Accion.Text.Equals("Agregar"))
        {
            mensaje += "- El correo ya se encuentra registrado.<br/>";
        }

        if (TB_Contrasena.Text.Equals("") || TB_Repetir_Contrasena.Text.Equals(""))
        {
            mensaje += "- Los campos de contraseña estan vacios.<br/>";
        }
        else if (!TB_Contrasena.Text.Equals(TB_Repetir_Contrasena.Text))
        {
            mensaje += "- Las contraseñas no coinciden.<br/>";
        }

        if (!mensaje.Equals(""))
        {
            if (mensaje.Equals("- No hay consultorios disponibles.<br/>"))
            {
                return true;
            }
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
        if (int.Parse(DDL_Consultorio.SelectedItem.Value) != 0)
        {
            eMedico.Consultorio = int.Parse(DDL_Consultorio.SelectedItem.Value);
        }
        else
        {
            DataTable consultorio = dBConsultorio.obtenerConsultorio(TB_Consultorio.Text.ToString());
            eMedico.Consultorio = int.Parse(consultorio.Rows[0]["id"].ToString());
        }
        eMedico.Correo = TB_Correo.Text.Trim();
        eMedico.Password = TB_Contrasena.Text;
        return eMedico;
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;
        if (validarDatos())
        {
            EMedico eMedico = recolectarDatos();
            DBMedico dBMedico = new DBMedico();
            DBConsultorio dBConsultorio = new DBConsultorio();

            if (btnAccion.Text.Equals("Agregar"))
            {
                dBMedico.CrearMedico(eMedico);
                if (eMedico.Consultorio != Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio);
                    dBConsultorio.liberarDisponibilidad(Convert.ToInt32(Session["consultorio"]));
                }

            }
            else if (btnAccion.Text.Equals("Actualizar"))
            {
                dBMedico.actualizarMedico(eMedico);
                if (eMedico.Consultorio != Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio);
                    dBConsultorio.liberarDisponibilidad(Convert.ToInt32(Session["consultorio"]));
                }
                else if (eMedico.Consultorio == Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio);
                }
            }
            else if (btnAccion.Text.Equals("Eliminar"))
            {

            }
            Response.Redirect(Session["PaginaAnterior"].ToString());
        }
    }
}