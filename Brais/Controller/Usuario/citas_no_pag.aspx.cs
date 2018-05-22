using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_citas_no_pag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBCitasUsr user = new DBCitasUsr();
        DataTable info = new DataTable();
        //DE MOMENTO ESTO ES UN TEST
        EUsuario usera_lo = (EUsuario)Session["usuario"];
        String id_user = usera_lo.Identificacion;
        info = user.citas_pendientes_pago(id_user);
        GridView1.DataSource = info;
        GridView1.DataBind();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id = btn.CommandArgument;
        Session["id_payment"] = int.Parse(id);
        Response.Redirect("~/View/Usuario/pago.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}