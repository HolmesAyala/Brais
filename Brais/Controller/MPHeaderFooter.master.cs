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
        if ( Session["usuario"] != null)
        {
            BTN_Casa.Visible = true;
            menu_principal.Visible = false;
        }
    }

    protected void BTN_PaginaPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/PaginaPrincipal.aspx");
    }

    protected void BTN_SobreNosotros_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/SobreNosotros.aspx");
    }

    protected void BTN_CrearCuenta_Click(object sender, EventArgs e)
    {
        //Session["Accion"] = "Insertar";
        //Session["Crear_cuenta"] = "Crear cuenta";
        //Session["PaginaAnterior"] = "~/View/Login.aspx";
        Response.Redirect("~/View/Register.aspx");
    }

    protected void BTN_Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Login.aspx");
    }


    protected void BTN_Casa_Click(object sender, EventArgs e)
    {
        Response.Redirect(Session["casa"].ToString());
    }
}
