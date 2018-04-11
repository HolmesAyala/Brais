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
        Response.Cache.SetNoStore();
        if (Session["usuario"] == null)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        if (Session["Accion"] != null)
        {
            if (Session["Accion"].ToString().Equals("Insertar"))
            {
                //adecuarParaInsertar();
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

    protected void adecuarParaActualizar()
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
        DDL_Consultorio.SelectedIndex = eMedico.Consultorio;
        TB_Correo.Text = eMedico.Correo;
        TB_Contrasena.Attributes.Add("value", eMedico.Password);
        TB_Repetir_Contrasena.Attributes.Add("value", eMedico.Password);
        BTN_Accion.Text = "Actualizar";
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Response.Redirect(Session["PaginaAnterior"].ToString());
    }
}