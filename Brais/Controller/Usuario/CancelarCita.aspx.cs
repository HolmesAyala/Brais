using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_CancelarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitasPaciente();
    }

    protected void obtenerCitasPaciente()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DBCita dBCita = new DBCita();
        GV_Cancelar_Cita.DataSource = dBCita.obtenerCitasPaciente(eUsuario.Identificacion);
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
        DBUsuario dBUsuario = new DBUsuario();
        ECita eCita = new ECita();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        Boolean resultado = validarCita(btnSeleccionar);
        if (resultado == true)
        {
            eCita.Id = Convert.ToInt32(btnSeleccionar.CommandName);
            eCita.EUsuario = eUsuario;
            DBCita.eliminarCita(eCita);
            obtenerCitasPaciente();
        }
        else
        {
            string script = @"<script type='text/javascript'>alert('Las citas se deben cancelar con 6 horas de antelación!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected Boolean validarCita(Button btnSeleccionar)
    {
        DataTable cita = new DataTable();
        cita = DBCita.obtenerCita(Convert.ToInt32(btnSeleccionar.CommandName));
        DateTime fecha_actual = new DateTime();
        fecha_actual = DateTime.Now;
        String hora_cita, aux_fecha;
        DateTime dia_cita = new DateTime();
        dia_cita = DateTime.Parse(cita.Rows[0]["dia"].ToString());
        aux_fecha = Convert.ToString(dia_cita.ToShortDateString());
        hora_cita = cita.Rows[0]["hora_inicio"].ToString();
        aux_fecha = aux_fecha + " " + hora_cita;
        System.TimeSpan diferencia_dias = DateTime.Parse(aux_fecha).Subtract(fecha_actual);
        int dias = int.Parse(diferencia_dias.ToString("dd"));
        int horas = int.Parse(diferencia_dias.ToString("hh"));
        if (dias > 0)
        {
            return true;
        }
        else if (horas >= 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void GV_Cancelar_Cita_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}