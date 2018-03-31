using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_Usuario_MPUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_ActualizarDatos_Click(object sender, EventArgs e)
    {

    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {

    }

    protected void BTN_AsignarCita_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Usuario/AsignarCita.aspx");
    }

    protected void BTN_ReprogramarCita_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Usuario/ReprogramarCita.aspx");
    }

    protected void BTN_CancelarCita_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Usuario/CancelarCita.aspx");
    }

    protected void BTN_VerCitasProgramadas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Usuario/VerCitasProgramadas.aspx");
    }
}
