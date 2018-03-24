using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;


public partial class View_Login : System.Web.UI.Page
{

    private String mensaje_usuario = "Escriba su usuario";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Ingresar_Click(object sender, EventArgs e)
    {
        EUsuario datosUsuario= new EUsuario();

        datosUsuario.Identificacion = Tx_Identificacion.Text.ToString();
        datosUsuario.Password = Tx_contrasena.Text.ToString();

        DBLogin traerUsuario = new DBLogin();

        DataTable usuario = traerUsuario.Login(datosUsuario);

        if (usuario.Rows.Count == 0)
        {
            L_Informacion.Text = "El usuario no existe";
            Session["identificacion"] = null;
        }
        else
        {
            Session["identificacion"] = usuario.Rows[0]["identificacion"];
            Session["contrasena"] = usuario.Rows[0]["contrasena"];
            Response.Redirect("PaginaPrincipal.aspx");
            //L_Informacion.Text = "Correcto! " + usuario.Rows[0]["usuario"] + usuario.Rows[0]["clave"] + usuario.Rows[0]["rol_id"];
        }
    }
}