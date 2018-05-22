using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_VerCitasProgramadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitasProgramadas();
    }

    protected void obtenerCitasProgramadas()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DBCita dBCita = new DBCita();
        GV_Ver_citas.DataSource = dBCita.obtenerCitasPaciente(eUsuario.Identificacion);
        GV_Ver_citas.DataBind();
    }


    protected void GV_Cancelar_Cita_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Ver_citas.PageIndex = e.NewPageIndex;
        obtenerCitasProgramadas();
    }

    protected void BT_Date_Click(object sender, EventArgs e)
    {
        //LLAMO A LA VISTA CON EL REPORTE
        Response.Redirect("vista_reporte_historial_user.aspx");
    }
}