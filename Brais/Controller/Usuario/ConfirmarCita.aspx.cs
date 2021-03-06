﻿using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Administrador;
using Utilitaria.Clases.Usuario;

public partial class View_Usuario_ConfirmarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LCita lCita = new LCita();
            lCita.validarSession(Session["eCita"]);
            mostrarDatos();
        }
        catch { Response.Redirect("~/View/Usuario/AsignarCita.aspx"); }
        
    }

    protected void mostrarDatos()
    {
        ECita eCita = (ECita)Session["eCita"];
        EUsuario eUsuario = (EUsuario)Session["usuario"];

        L_Nombre_Paciente_f.Text = eUsuario.Nombre + " " + eUsuario.Apellido;
        L_Especialidad_f.Text = eCita.EMedico.EEspecialidad.Nombre;
        L_Fecha_f.Text = Convert.ToString(DateTime.Parse(eCita.Dia).ToShortDateString());
        L_Hora_f.Text = eCita.HoraInicio;
        L_Medico_f.Text = eCita.EMedico.Nombre + " " + eCita.EMedico.Apellido;

    }


    protected void BTN_ConfirmarCita_Click(object sender, EventArgs e)
    {
        ECita eCita = (ECita)Session["eCita"];
        LCita lCita = new LCita();
        try
        {
            lCita.verificarDisponibilidadCita(eCita.Id);
            eCita.EUsuario = (EUsuario)Session["usuario"];
            eCita.Session = Session.SessionID;
            lCita.reservarCita(eCita);
            string script = @"<script type='text/javascript'>alert('Agendo la cita correctamente!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        catch
        {
            string script = @"<script type='text/javascript'>alert('La cita ya se encuentra reservada!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        BTN_ConfirmarCita.Enabled = false;
    }

    protected void Btn_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Usuario/AsignarCita.aspx");
    }
}