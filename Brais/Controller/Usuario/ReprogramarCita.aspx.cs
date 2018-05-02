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
}