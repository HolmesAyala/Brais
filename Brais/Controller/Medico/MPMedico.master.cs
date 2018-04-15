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

        //LB_MensajeBienvenida.Text += ((EMedico)Session["usuario"]).Nombre + " " + ((EMedico)Session["usuario"]).Apellido;

    }

    protected void BTN_VerPacientes_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Medico/VerPacientes.aspx");
    }

    protected void BTN_CerrarSesion_Click(object sender, EventArgs e)
    {
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



    protected void BTN_ProbarHistorial_Click(object sender, EventArgs e)
    {
        DBUsuario dBUsuario = new DBUsuario();
        Session["Paciente"] = Funcion.dataTableToEUsuario(dBUsuario.obtenerUsuario("0000"));
        DBMedico dBMedico = new DBMedico();
        Session["Medico"] = Funcion.dataTableToEMedico(dBMedico.obtenerMedico("10922"));
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Medico/HistorialPaciente.aspx");
    }
}
