using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_RecuperarContrasenaPasoUno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void BTN_Restablecer_Click(object sender, EventArgs e)
    {
        DBRecuperarContrasena dBRecuperarContrasena = new DBRecuperarContrasena();
        DBUsuario dBUsuario = new DBUsuario();

        if (dBUsuario.obtenerUsuario(TB_Identificacion.Text.ToString()).Rows.Count == 0)
        {
            LB_Mensaje.Text = "El usuario NO es valido!";
            TB_Identificacion.Text = "";
        }
        else if (dBRecuperarContrasena.verificarExistenciaSolicitud(TB_Identificacion.Text.ToString()).Rows.Count > 0)
        {
            LB_Mensaje.Text = "Ya tiene una solicitud de restablecimiento, verifique en su correo.";
            TB_Identificacion.Text = "";
        }
        else
        {
            string token = encriptar(TB_Identificacion.Text.ToString());

            dBRecuperarContrasena.agregarSolicitudDeRestablecerContrasena(TB_Identificacion.Text.ToString(), token);

            string mensaje = "Su link para restablecer su contraseña: " + "http://localhost:51250/View/RecuperarContrasenaPasoDos.aspx?" + token;

            GestorCorreo gestorCorreo = new GestorCorreo();

            DataTable usuario = dBUsuario.obtenerUsuario(TB_Identificacion.Text.ToString());


            gestorCorreo.enviarCorreo(usuario.Rows[0]["correo"].ToString(), "Restablecer Contraseña", mensaje);

            LB_Mensaje.Text = "Se envio informacion a su correo!";

            TB_Identificacion.Text = "";

            TB_Identificacion.Enabled = false;

            BTN_Restablecer.Enabled = false;
        }

    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hashedBytes.Length; i++)
            output.Append(hashedBytes[i].ToString("x2").ToLower());

        return output.ToString();
    }

}