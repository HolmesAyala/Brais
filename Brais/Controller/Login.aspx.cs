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
            Session["usuario"] = null;
        }
        else
        {
            if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 3)
            {
                Session["usuario"] = Funcion.dataTableToEUsuario(usuario);
                Session["tipo"] = "3";
                Response.Redirect("Usuario/AsignarCita.aspx");
            }
            else if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 2)
            {
                Session["usuario"] = Funcion.dataTableToEMedico(usuario);
                Session["identificacion_medico"] = datosUsuario.Identificacion;
                Session["tipo"] = "2";
                Response.Redirect("~/View/Medico/VerPacientes.aspx");
            }
            else if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 1)
            {
                EUsuario eUsuario = new EUsuario();
                eUsuario.TipoUsuario = 1;
                Session["tipo"] = "1";
                Session["usuario"] = eUsuario;
                Response.Redirect("Administrador/VerUsuarios.aspx");
            }

            //L_Informacion.Text = "Correcto! " + usuario.Rows[0]["usuario"] + usuario.Rows[0]["clave"] + usuario.Rows[0]["rol_id"];
        }
    }
}