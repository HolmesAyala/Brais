using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Administrador;
using Utilitaria.Clases.Usuario;

public partial class View_Usuario_CancelarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitasPaciente();
    }

    protected void obtenerCitasPaciente()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        LCita lCita = new LCita();
        GV_Cancelar_Cita.DataSource = lCita.obtenerCitasPaciente(eUsuario.Identificacion);
        GV_Cancelar_Cita.DataBind();
    }


    protected void GV_Cancelar_Cita_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Cancelar_Cita.PageIndex = e.NewPageIndex;
        obtenerCitasPaciente();
    }

    protected void BTN_Seleccionar_Click(object sender, EventArgs e)
    {
        Button btnSeleccionar = (Button)sender;
        LCita lCita = new LCita();
        ECita eCita = new ECita();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        try {
            Boolean resultado = lCita.validarCita(Convert.ToInt32(btnSeleccionar.CommandName));
            eCita.Id = Convert.ToInt32(btnSeleccionar.CommandName);
            eCita.EUsuario = eUsuario;
            eCita.Session = Session.SessionID;
            lCita.eliminarCita(eCita);
            obtenerCitasPaciente();
        }
        catch
        {
            string script = @"<script type='text/javascript'>alert('Las citas se deben cancelar con 6 horas de antelación!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected void GV_Cancelar_Cita_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}