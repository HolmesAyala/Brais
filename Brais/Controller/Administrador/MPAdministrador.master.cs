using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica.Clases.Administrador;
using Utilitaria.Clases.Usuario;

public partial class View_Administrador_MPAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LAdministrador lAdministrador = new LAdministrador();
            lAdministrador.validarUsuario((EUsuario)Session["usuario"]);
        }
        catch(Exception ex)
        {
            Response.Redirect("~/View/Login.aspx");
        }
        
    }

    protected void BTN_VerUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/VerUsuarios.aspx");
    }

    protected void BTN_VerMedicos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/VerMedicos.aspx");
    }

    protected void BTN_ConfigurarParametros_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/parametros.aspx");
    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session["usuario"] = null;
        Response.Redirect("~/View/Login.aspx");
    }
}
