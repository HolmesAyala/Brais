using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_MPAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_VerUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/VerUsuarios.aspx");
    }

    protected void BTN_VerMedicos_Click(object sender, EventArgs e)
    {

    }

    protected void BTN_ConfigurarParametros_Click(object sender, EventArgs e)
    {

    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {

    }
}
