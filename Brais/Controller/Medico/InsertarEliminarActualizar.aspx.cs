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

        DBMedico dBMedico = new DBMedico();

        EMedico eMedico = Funcion.dataTableToEMedico(dBMedico.obtenerMedico(identificacion));

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

        DBConsultorio dBConsultorio = new DBConsultorio();
        DataRow drConsultorioMedico = dBConsultorio.obtenerConsultorio(eMedico.Consultorio).Rows[0];

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
        DBEspecialidad dBEspecialidad = new DBEspecialidad();
        DDL_Especialidad.Items.Add(new ListItem("Ninguno", "0"));

        foreach (DataRow fila in dBEspecialidad.obtenerTipoEspecialidad().Rows)
        {
            ListItem listItem = new ListItem(fila["nombre"].ToString(), fila["id"].ToString());
            DDL_Especialidad.Items.Add(listItem);
        }
    }

    protected void cargarConsultoriosDisponibles()
    {
        DBConsultorio dBConsultorio = new DBConsultorio();
        foreach (DataRow fila in dBConsultorio.obtenerConsultoriosDisponibles().Rows)
        {
            ListItem listItem = new ListItem(fila["nombre_consultorio"].ToString(), fila["id"].ToString());
            DDL_Consultorio.Items.Add(listItem);
        }
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
            if (BTN_Accion.Text.Equals("Agregar") && DBUsuario.verificarUsuario(TB_Numero_Documento.Text.Trim()) )
            {
                mensaje += "- YA EXISTE UN MÉDICO CON ESA IDENTIFICACION.<br/>";
            }

            if (Session["identificacion_medico"] != null)
            {
                string identificacion = Session["identificacion_medico"].ToString();

                DBUsuario dBUsuario = new DBUsuario();

                DBMedico dBMedico = new DBMedico();

                EMedico eMedico = Funcion.dataTableToEMedico( dBMedico.obtenerMedico(TB_Numero_Documento.Text.Trim()) );

                if (BTN_Accion.Text.Equals("Actualizar") &&
                     eMedico.Identificacion != TB_Numero_Documento.Text.Trim() &&
                     !DBUsuario.verificarUsuario((TB_Numero_Documento.Text.Trim())))
                {
                    mensaje += "- YA EXISTE UN USUARIO CON ESA IDENTIFICACION<br/>";
                }
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

        if (DDL_Especialidad.SelectedItem.Text == "Ninguno")
        {
            mensaje += "- No ha seleccionado la especialidad.<br/>";
        }

        if (TB_Correo.Text.Trim().Equals(""))
        {
            mensaje += "- El campo correo esta vacio.<br/>";
        }
        else if (!DBUsuario.validarExistenciaCorreo(TB_Correo.Text.Trim()) && BTN_Accion.Text.Equals("Agregar"))
        {
            mensaje += "- El correo ya se encuentra registrado.<br/>";
        }
        else if (Session["identificacion_medico"] != null)
        {
            string identificacion = Session["identificacion_medico"].ToString();

            DBMedico dBMedico = new DBMedico();

            EMedico eMedico = Funcion.dataTableToEMedico(dBMedico.obtenerMedico(identificacion));

            if (BTN_Accion.Text.Equals("Actualizar") &&
                 eMedico.Correo != TB_Correo.Text.Trim() &&
                 !DBUsuario.validarExistenciaCorreo((TB_Correo.Text.Trim())))
            {
                mensaje += "- El correo ya se encuentra registrado<br/>";
            }
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
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio, Session.SessionID);
                    dBConsultorio.liberarDisponibilidad(Convert.ToInt32(Session["consultorio"]), Session.SessionID);
                }
                else if (eMedico.Consultorio == Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio, Session.SessionID);
                }

            }
            else if (btnAccion.Text.Equals("Actualizar"))
            {
                dBMedico.actualizarMedico(eMedico);
                if (eMedico.Consultorio != Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio, Session.SessionID);
                    dBConsultorio.liberarDisponibilidad(Convert.ToInt32(Session["consultorio"]), Session.SessionID);
                }
                else if (eMedico.Consultorio == Convert.ToInt32(Session["consultorio"]))
                {
                    dBConsultorio.guardarDisponibilidad(eMedico.Consultorio, Session.SessionID);
                }
            }

            Session["Accion"] = null;
            Response.Redirect(Session["PaginaAnterior"].ToString());
        }
    }
}