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
        if (Session["usuario"] != null)
        {
            if (Session["usuario"].GetType() == new EMedico().GetType())
            {
                Response.Redirect("~/View/Medico/VerPacientes.aspx");
            }
            else if (Session["usuario"].GetType() == new EUsuario().GetType())
            {
                if (((EUsuario)Session["usuario"]).TipoUsuario.Equals(1))
                {
                    Response.Redirect("~/View/Administrador/VerUsuarios.aspx");
                }
                else
                {
                    Response.Redirect("~/View/Usuario/AsignarCita.aspx");
                }
            }

        }
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
            L_Informacion.Text = "Usuario o contraseña incorrectos";
            Session["usuario"] = null;
        }
        else
        {
            if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 3)
            {
                Session["usuario"] = Funcion.dataTableToEUsuario(usuario);
                Session["casa"] = "~/View/Usuario/AsignarCita.aspx";
                Response.Redirect("~/View/Usuario/AsignarCita.aspx");
            }
            else if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 2)
            {
                Session["usuario"] = Funcion.dataTableToEMedico(usuario);
                Session["identificacion_medico"] = datosUsuario.Identificacion;
                Session["casa"] = "~/View/Medico/VerPacientes.aspx";
                Response.Redirect("~/View/Medico/VerPacientes.aspx");
            }
            else if ( int.Parse(usuario.Rows[0]["tipo"].ToString()) == 1)
            {
                EUsuario eUsuario = new EUsuario();
                eUsuario.TipoUsuario = 1;
                Session["usuario"] = eUsuario;
                Session["casa"] = "~/View/Administrador/VerUsuarios.aspx";
                Response.Redirect("~/View/Administrador/VerUsuarios.aspx");
            }
        }
    }
}