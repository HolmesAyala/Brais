using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica.Clases;
using Data.Clases.Usuario;
using Logica.Clases.Usuario;

public partial class View_Medico_VerPacientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerDatosPaciente();
    }

    protected void obtenerDatosPaciente()
    {
        try
        {
            LUsuario lUsuario = new LUsuario();
            lUsuario.validarUsuario(Session["identificacion_medico"]);
            GV_Pacientes.DataSource = lUsuario.obtenerPacientesAgendados(Session["identificacion_medico"]);
            GV_Pacientes.DataBind();
        }
        catch { }
    }


    protected void GV_Pacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Pacientes.PageIndex = e.NewPageIndex;
        obtenerDatosPaciente();
    }

    protected void BTN_Modificar_Historial_Click(object sender, EventArgs e)
    {
        Button btnModificarHistorial = (Button)sender;
        LFuncion lFuncion = new LFuncion();
        string idPaciente = btnModificarHistorial.CommandName;

        DAOUsuario dBUsuario = new DAOUsuario();

        Session["paciente"] = lFuncion.dataTableToEUsuario(dBUsuario.obtenerUsuario(idPaciente));

        Session["medico"] = Session["usuario"];

        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;

        Response.Redirect("~/View/Medico/HistorialPaciente.aspx");
    }

    protected void BTN_Confirmar_Cita_Click(object sender, EventArgs e)
    {
    }


    protected void BTN_Reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Medico/ReporteCitas.aspx");
    }
}