using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_AsignarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(DDL_TipoCita.SelectedIndex == 0)
        {
            Session["fechasDisponibles"] = null;
        }
    }

    protected void DDL_TipoCita_SelectedIndexChanged(object sender, EventArgs e)
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DataTable dtCitas = DBCita.obtenerCitas(int.Parse(DDL_TipoCita.SelectedValue.ToString()), eUsuario);
        Session["fechasDisponibles"] = obtenerFechaDeCitas(dtCitas);
        C_FechasDisponibles.SelectedDate = DateTime.MinValue;
        mostrarDisponibilidadHoraria();
    }

    protected List<DateTime> obtenerFechaDeCitas(DataTable dtCitas)
    {
        List<DateTime> fechas = new List<DateTime>();
        foreach (DataRow fila in dtCitas.Rows)
        {
            fechas.Add(DateTime.Parse(fila["dia"].ToString()));
        }
        return fechas;
    }

    protected void C_FechasDisponibles_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = validarFecha(e.Day.Date);
        if (e.Day.IsSelectable)
        {
            e.Cell.BorderColor = Color.Red;
            e.Cell.BorderStyle = BorderStyle.Ridge;
            e.Cell.BorderWidth = 2;
        }

    }

    protected Boolean validarFecha(DateTime dateTime)
    {
        List<DateTime> fechasDisponibles = new List<DateTime>();

        if (Session["fechasDisponibles"] != null) fechasDisponibles = (List<DateTime>)Session["fechasDisponibles"];

        foreach (DateTime fecha in fechasDisponibles)
        {
            if (dateTime == fecha)
            {
                return true;
            }
        }
        return false;
    }


    protected void C_FechasDisponibles_SelectionChanged(object sender, EventArgs e)
    {
        mostrarDisponibilidadHoraria();
    }

    protected void mostrarDisponibilidadHoraria()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DataTable dtCitas = DBCita.obtenerCitas(int.Parse(DDL_TipoCita.SelectedValue.ToString()), C_FechasDisponibles.SelectedDate, eUsuario);
        GV_DisponibilidadHoraria.DataSource = dtCitas;
        GV_DisponibilidadHoraria.DataBind();
    }


    protected void BTN_SeleccionarCita_Click(object sender, EventArgs e)
    {
        Button btnSeleccionarCita = (Button)sender;
        
        string idCita = btnSeleccionarCita.CommandName;

        ECita eCita = ECita.dataTableToECita(DBCita.obtenerCita(int.Parse(idCita)));

        Session["eCita"] = eCita;

        if (DBCita.verificarDisponibilidadCita(eCita.Id))
        {
            DDL_TipoCita.SelectedIndex = 0;
            C_FechasDisponibles.SelectedDate = DateTime.MinValue;

            Response.Redirect("~/View/Usuario/ConfirmarCita.aspx");
        }
        else
        {
            string script = @"<script type='text/javascript'>alert('La cita ya se encuentra reservada!');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        mostrarDisponibilidadHoraria();
    }

}