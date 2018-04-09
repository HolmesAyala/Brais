using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_MPHeaderFooter : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_PaginaPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaginaPrincipal.aspx");
    }

    protected void BTN_SobreNosotros_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/SobreNosotros.aspx");
    }

    protected void BTN_CrearCuenta_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void BTN_Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BTN_Recargar_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaginaPrincipal.aspx");
    }

}
