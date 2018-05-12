using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_Usuario_cambiarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable datos = new DataTable();
        DBCitasUsr cite = new DBCitasUsr();
        datos = cite.obtener_disp_tipo(int.Parse((Session["id_cita"].ToString())));
        if (datos.Rows.Count > 0)
        {
            GridView1.DataSource = datos;
            GridView1.DataBind();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void b_cam_Click(object sender, EventArgs e)
    {
        //Se ACTUALIZA LA CITA Y FALTAN  VALIDACIONES
        DBCitasUsr bd = new DBCitasUsr();
        Button btn = (Button)sender;
        int id_cita_nueva = int.Parse(btn.CommandArgument.ToString());
        EUsuario usr = (EUsuario)Session["usuario"];
        bd.act_cita(usr.Identificacion, int.Parse((Session["id_cita"].ToString())), id_cita_nueva);
        Response.Redirect("ReprogramarCita.aspx");

    }
}