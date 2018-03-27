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

    }

    protected void BTN_Buscar_Click(object sender, EventArgs e)
    {
        llenarDatosUsuarios(TB_Buscar.Text.Trim());
    }

    protected void BTN_Modificar_Click(object sender, EventArgs e)
    {
        Button btnModificar = (Button)sender;
        Label lbModificar = (Label)btnModificar.Parent.Controls[1];
        imprimirConsola("Quiere Modificar a: "+lbModificar.Text);
    }

    protected void BTN_Eliminar_Click(object sender, EventArgs e)
    {
        Button btnEliminar = (Button)sender;
        Label lbEliminar = (Label)btnEliminar.Parent.Controls[1];
        DBUsuario dBUsuario = new DBUsuario();
        dBUsuario.eliminarUsuario(lbEliminar.Text);
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
}