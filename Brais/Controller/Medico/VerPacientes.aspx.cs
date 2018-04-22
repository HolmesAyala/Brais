using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_VerPacientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerDatosPaciente();
    }

    protected void obtenerDatosPaciente()
    { 
        DBUsuario dBUsuario= new DBUsuario();
        GV_Pacientes.DataSource = dBUsuario.obtenerPaciente((String)Session["identificacion_medico"]);
        GV_Pacientes.DataBind();
    }


    protected void GV_Pacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Pacientes.PageIndex = e.NewPageIndex;
        obtenerDatosPaciente();
    }

    protected void BTN_Modificar_Historial_Click(object sender, EventArgs e)
    {
        Button btnModificarHistorial = (Button)sender;
        string idPaciente = btnModificarHistorial.CommandName;

        DBUsuario dBUsuario = new DBUsuario();

        Session["paciente"] = Funcion.dataTableToEUsuario(dBUsuario.obtenerUsuario(idPaciente));

        Session["medico"] = Session["usuario"];

        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;

        Response.Redirect("~/View/Medico/HistorialPaciente.aspx");
    }

    protected void BTN_Confirmar_Cita_Click(object sender, EventArgs e)
    {
    }

}