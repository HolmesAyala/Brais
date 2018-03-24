using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Descripción breve de GestorCorreo
/// </summary>
public class GestorCorreo
{
    public GestorCorreo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void enviarCorreo(String correoDestino, String asunto, String mensaje)
    {
        SmtpClient cliente = new SmtpClient();
        cliente.Host = "smtp.gmail.com";
        MailMessage m = new MailMessage(
                  "edgarkrejci12345@gmail.com",
                  correoDestino,
                  asunto,
                  mensaje);

        cliente.Credentials = new NetworkCredential("edgarkrejci12345@gmail.com", "mediayfelix.12345");
        cliente.Port = 587;
        cliente.EnableSsl = true;
        cliente.Send(m);
    }

}