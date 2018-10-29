using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Usuario;

public partial class Controller_Usuario_MPUsuario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LUsuario lUsuario = new LUsuario();
            lUsuario.validarUsuarioTipo(Session["usuario"]);
            Response.Redirect("~/View/Login.aspx");
        }
        catch
        {
            String nombre = "Bienvenido: " + ((EUsuario)Session["usuario"]).Nombre + " " + ((EUsuario)Session["usuario"]).Apellido;
            L_Bienvenido.Text = nombre;
            L_Bienvenido.Visible = true;
        }
    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session["usuario"] = null;
        Response.Redirect("~/View/Login.aspx");
    }

    protected void BTN_ActualizarDatos_Click(object sender, EventArgs e)
    {
        Session["Accion"] = "Actualizar";
        Session["identificacion"] = ((EUsuario)Session["usuario"]).Identificacion;
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Usuario/InsertarEliminarActualizar.aspx");
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

    protected void BTN_PAGO_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/view/Usuario/citas_no_pag.aspx");
    }

    protected void BTN_Comentarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/view/Usuario/Comentarios.aspx");
    }

    protected void BTN_Historial_Paceinte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/view/Usuario/ReporteHistorial.aspx");
    }
}
