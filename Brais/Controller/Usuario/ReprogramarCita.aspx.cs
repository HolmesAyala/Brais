using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Administrador;
using Logica.Clases.Usuario;

public partial class View_Usuario_ReprogramarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EUsuario usr = (EUsuario) Session["usuario"];
        LUsuario lUsuario = new LUsuario();
        DataTable datos = new DataTable();
        datos = lUsuario.obtener_citas_user(usr.Identificacion);
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

        ECita eCita = new ECita();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        try
        {
            Boolean resultado = validarCita(id);
            Response.Redirect("~/View/Usuario/cambiarCita.aspx");
        }
        catch
        {
            string script = @"<script type='text/javascript'>alert('Las citas se deben cancelar con 6 horas de antelación!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected Boolean validarCita(String id)
    {
        DataTable cita = new DataTable();
        LCita lCita = new LCita();
        cita = lCita.obtenerCita(Convert.ToInt32(id));
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
            throw new Exception();
        }
    }

    protected void GV_CitasAgendadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EUsuario usr = (EUsuario)Session["usuario"];
        LUsuario lUsuario = new LUsuario();
        DataTable datos = new DataTable();
        datos = lUsuario.obtener_citas_user(usr.Identificacion);
        GV_CitasAgendadas.DataSource = datos;
        GV_CitasAgendadas.DataBind();
    }

    protected void GV_CitasAgendadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
}