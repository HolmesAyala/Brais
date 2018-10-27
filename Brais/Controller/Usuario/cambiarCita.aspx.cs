using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilitaria.Clases.Usuario;
using Logica.Clases.Usuario;

public partial class View_Usuario_cambiarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        Response.Cache.SetNoStore();
        DataTable datos = new DataTable();
        LCita lCita = new LCita();
        datos = lCita.obtener_disp_tipo(int.Parse((Session["id_cita"].ToString())));
        GridView1.DataSource = datos;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataTable datos = new DataTable();
        LCita lCita = new LCita();
        datos = lCita.obtener_disp_tipo(int.Parse((Session["id_cita"].ToString())));
        GridView1.DataSource = datos;
        GridView1.DataBind();
    }

    protected void b_cam_Click(object sender, EventArgs e)
    {
        //Se ACTUALIZA LA CITA Y FALTAN  VALIDACIONES
        LCita lCita = new LCita();
        Button btn = (Button)sender;
        int id_cita_nueva = int.Parse(btn.CommandArgument.ToString());
        EUsuario usr = (EUsuario)Session["usuario"];
        lCita.act_cita(usr.Identificacion, int.Parse((Session["id_cita"].ToString())), id_cita_nueva, Session.SessionID);
        Response.Redirect("ReprogramarCita.aspx");

    }
}