using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_RecuperarContrasenaPasoDos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Request.QueryString.Count > 0)
        {
            string token = Request.QueryString[0];

            DBRecuperarContrasena dBRecuperarContrasena = new DBRecuperarContrasena();

            DataTable solicitudValida = dBRecuperarContrasena.obtenerSolicitudValida(token);

            if(solicitudValida.Rows.Count > 0)
            {
                Session["identificacion"] = solicitudValida.Rows[0]["identificacion_usuario"].ToString();
            }
            else
            {
                DataTable solicitud = dBRecuperarContrasena.obtenerSolicitud(token);

                if (solicitud.Rows.Count > 0)
                {
                    dBRecuperarContrasena.eliminarSolicitud(solicitud.Rows[0]["identificacion_usuario"].ToString());
                }

                Response.Redirect("RecuperarContrasenaPasoUno.aspx");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void BTN_Cambiar_Click(object sender, EventArgs e)
    {
        if (validarContrasena())
        {
            DBRecuperarContrasena dBFunciones = new DBRecuperarContrasena();
            dBFunciones.restablecerContrasena(Session["identificacion"].ToString(), TB_Contrasena.Text);
            dBFunciones.eliminarSolicitud(Session["identificacion"].ToString());
            deshabilitarCampos();
            LB_Mensaje.Text = "Restablecio su contraseña correctamente!";
        }
    }

    protected Boolean validarContrasena()
    {
        if (TB_Contrasena.Text.Equals("") || TB_Contrasena.Text.Equals(""))
        {
            LB_Mensaje.Text = "Los campos no pueden quedar vacios!";
            return false;
        }
        if (!TB_Contrasena.Text.Equals(TB_RepetirContrasena.Text))
        {
            LB_Mensaje.Text = "Los campos no coinciden!";
            return false;
        }
        return true;
    }

    protected void deshabilitarCampos()
    {
        BTN_Cambiar.Enabled = false;
        TB_Contrasena.Enabled = false;
        TB_RepetirContrasena.Enabled = false;
    }
}