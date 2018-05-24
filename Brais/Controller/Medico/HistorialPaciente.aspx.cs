using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_HistorialPaciente : System.Web.UI.Page
{

    EMedico eMedico;

    EUsuario eUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["medico"] != null  && Session["paciente"] != null)
        {
            mostrarInformacionBasica();
        }
        else
        {
            Response.Redirect("~/View/Login.aspx");
        }

    }

    protected void mostrarInformacionBasica()
    {
        eMedico = (EMedico)Session["medico"];
        eUsuario = (EUsuario)Session["paciente"];

        TB_Fecha.Text = DateTime.Now.ToShortDateString();
        TB_NombreMedico.Text = eMedico.Nombre + " " + eMedico.Apellido;
        TB_NombrePaciente.Text = eUsuario.Nombre + " " + eUsuario.Apellido;

        DBEspecialidad dBEspecialidad = new DBEspecialidad();
        TB_NombreServicio.Text = dBEspecialidad.obtenerEspecialidad(eMedico.TipoEspecialidad).Rows[0]["nombre"].ToString();

        cargarDatosHistorial(eUsuario.Identificacion);

        if (GV_Historial.Rows.Count <= 0)
        {
            LB_Mensaje.Text = "El paciente no tiene historial medico.";
        }

    }


    protected void BTN_Agregar_Click(object sender, EventArgs e)
    {
        EHistorial eHistorial = new EHistorial();

        eHistorial.Fecha = TB_Fecha.Text.Trim();
        eHistorial.IdMedico = eMedico.Identificacion;
        eHistorial.IdUsuario = eUsuario.Identificacion;
        eHistorial.Servicio = TB_NombreServicio.Text.Trim();
        eHistorial.MotivoConsulta = TB_MotivoConsulta.Text.Trim();
        eHistorial.Observacion = TB_Observacion.Text.Trim();
        eHistorial.Session = Session.SessionID;

        DBHistorial.agregarHistorial(eHistorial);

        Session["medico"] = null;
        Session["paciente"] = null;

        if (Session["paginaAnterior"] != null)
        {
            Response.Redirect(Session["paginaAnterior"].ToString());
        }
    }

    protected void cargarDatosHistorial(string idUsuario)
    {
        DBHistorial dBHistorial = new DBHistorial();
        GV_Historial.DataSource = dBHistorial.obtenerHistorial(idUsuario);
        GV_Historial.DataBind();
    }

    protected void GV_Historial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Historial.PageIndex = e.NewPageIndex;
        cargarDatosHistorial(eUsuario.Identificacion);
    }

}