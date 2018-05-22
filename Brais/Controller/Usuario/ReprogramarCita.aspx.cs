using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_Usuario_ReprogramarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EUsuario usr = (EUsuario) Session["usuario"];
        DBCitasUsr cite = new DBCitasUsr();
        DataTable datos = new DataTable();
        datos = cite.obtener_citas_user(usr.Identificacion);
        GV_CitasAgendadas.DataSource = datos;
        GV_CitasAgendadas.DataBind();
    }

    //AL PRESIONAR EL BOTON SE VAN A CARGAR LAS CITAS DEL MISMO TIPO EN EL OTRO GRIDVIEW
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id;
        id = btn.CommandArgument.ToString();
        Session["id_cita"] = id;
        DBUsuario dBUsuario = new DBUsuario();
        ECita eCita = new ECita();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        Boolean resultado = validarCita(id);
        if (resultado == true)
        {
            Response.Redirect("~/View/Usuario/cambiarCita.aspx");
        }
        else
        {
            string script = @"<script type='text/javascript'>alert('Las citas se deben cancelar con 6 horas de antelación!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }

    protected Boolean validarCita(String id)
    {
        DataTable cita = new DataTable();
        cita = DBCita.obtenerCita(Convert.ToInt32(id));
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

    protected void GV_CitasAgendadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EUsuario usr = (EUsuario)Session["usuario"];
        DBCitasUsr cite = new DBCitasUsr();
        DataTable datos = new DataTable();
        datos = cite.obtener_citas_user(usr.Identificacion);
        GV_CitasAgendadas.DataSource = datos;
        GV_CitasAgendadas.DataBind();
    }

    protected void GV_CitasAgendadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
}