using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_VerUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        llenarDatosUsuarios("");
    }

    protected void BTN_AgregarUsuario_Click(object sender, EventArgs e)
    {
        Session["Accion"] = "Insertar";
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Usuario/InsertarEliminarActualizar.aspx");
    }

    protected void BTN_Buscar_Click(object sender, EventArgs e)
    {
        llenarDatosUsuarios(TB_Buscar.Text.Trim());
    }

    protected void BTN_Modificar_Click(object sender, EventArgs e)
    {
        Button btnModificar = (Button)sender;
        Session["Accion"] = "Actualizar";
        Session["identificacion"] = btnModificar.CommandName;
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Usuario/InsertarEliminarActualizar.aspx");
    }

    protected void BTN_Eliminar_Click(object sender, EventArgs e)
    {
        Button btnEliminar = (Button)sender;
        DBUsuario dBUsuario = new DBUsuario();
        dBUsuario.eliminarUsuario(btnEliminar.CommandName, Session.SessionID);
        llenarDatosUsuarios(TB_Buscar.Text.Trim());
    }

    protected void GV_Usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Usuarios.PageIndex = e.NewPageIndex;
        llenarDatosUsuarios("");
    }

    protected void llenarDatosUsuarios(string id)
    {
        DBUsuario dBUsuario = new DBUsuario();
        GV_Usuarios.DataSource = dBUsuario.buscarUsuario(id);
        GV_Usuarios.DataBind();
    }

    protected void imprimirConsola(String mensaje)
    {
        Response.Write("<script>console.log('" + mensaje + "');</script>");
    }

    protected void BTN_Reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/ReporteUsuarios.aspx");
    }
}