using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_Usuario_ReprogramarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EUsuario usr = (EUsuario) Session["usuario"];
        DBCitasUsr cite = new DBCitasUsr();
        DataTable datos = new DataTable();
        datos = cite.obtener_citas_user(usr.Identificacion);
        GV_CitasAgendadas.DataSource = datos;
        GV_CitasAgendadas.DataBind();
    }
    //AL PRESIONAR EL BOTON SE VAN A CARGAR LAS CITAS DEL MISMO TIPO EN EL OTRO GRIDVIEW
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id;
        id = btn.CommandArgument.ToString();
        Session["id_cita"] = id;
        Response.Redirect("cambiarCita.aspx");
    }

    protected void GV_CitasAgendadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EUsuario usr = (EUsuario)Session["usuario"];
        DBCitasUsr cite = new DBCitasUsr();
        DataTable datos = new DataTable();
        datos = cite.obtener_citas_user(usr.Identificacion);
        GV_CitasAgendadas.DataSource = datos;
        GV_CitasAgendadas.DataBind();
    }

    protected void GV_CitasAgendadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
}