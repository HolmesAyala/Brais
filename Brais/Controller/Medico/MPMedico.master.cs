using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_MPMedico : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null || ((EMedico)Session["usuario"]).TipoUsuario != 2)
        {
            Response.Redirect("~/View/Login.aspx");
        }
        else
        {
            String nombre = "Bienvenido: Doctor(a) " + ((EMedico)Session["usuario"]).Nombre + " " + ((EMedico)Session["usuario"]).Apellido;
            L_Bienvenido.Text = nombre;
            L_Bienvenido.Visible = true;
        }
        
    }

    protected void BTN_VerPacientes_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Medico/VerPacientes.aspx");
    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session["Usuario"] = null;
        Response.Redirect("~/View/Login.aspx");
    }

    protected void BTN_ActualizarDatos_Click(object sender, EventArgs e)
    {
        Session["Accion"] = "Actualizar";
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Medico/InsertarEliminarActualizar.aspx");
    }

    protected void BTN_VerPacientes_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Medico/VerPacientes.aspx");
    }

    protected void BTN_HorarioTrabajo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Medico/HorarioTrabajo.aspx");
    }

}
