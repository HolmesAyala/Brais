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
}