using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Medico;

//RETOCAR LOGICA PARA QUE ESTE DE ACUERDO AL FORMATO YA ESTABLECIDO DE JSON
public partial class View_Medico_HorarioTrabajoPrueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            if (!IsPostBack)
            {
                llenarInicio();
                llenarFin();
            }
            actualizarVistaDeHorario();
        }
    }

    protected void llenarInicio()
    {
        DateTime dtFin = DateTime.Parse("20:00");
        DateTime dtInicio = DateTime.Parse("06:00");
        int contador = 0;

        while (dtInicio < dtFin)
        {
            DDL_Inicio.Items.Insert(contador++, dtInicio.ToShortTimeString());
            dtInicio = dtInicio.AddHours(1);
        }
    }

    protected void DDL_Inicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenarFin();
        actualizarVistaDeHorario();
    }

    protected void llenarFin()
    {
        DateTime dtInicioSeleccionado = DateTime.Parse(DDL_Inicio.SelectedValue.ToString());
        DateTime dtFin = DateTime.Parse("20:00");
        int contador = 0;

        DDL_Fin.Items.Clear();
        while (dtInicioSeleccionado < dtFin)
        {
            dtInicioSeleccionado = dtInicioSeleccionado.AddHours(1);
            DDL_Fin.Items.Insert(contador++, dtInicioSeleccionado.ToShortTimeString());
        }
    }

    protected void BTN_Agregar_Click(object sender, EventArgs e)
    {
        DateTime dtInicio = DateTime.Parse(DDL_Inicio.SelectedValue.ToString());
        DateTime dtFin = DateTime.Parse(DDL_Fin.SelectedValue.ToString());

        Rango rango = new Rango();
        rango.Inicio = dtInicio.ToString("HH:mm");
        rango.Fin = dtFin.ToString("HH:mm");

        Dia diaSeleccionado = new Dia();
        diaSeleccionado.DiaSemana = int.Parse(DDL_Dia.SelectedValue.ToString());
        diaSeleccionado.Rangos.Add(rango);

        EMedico eMedico = (EMedico)Session["usuario"];

        List<Dia> dias = JsonConvert.DeserializeObject<List<Dia>>(eMedico.Horario);

        if (GestorHorario.agregarDia(dias, diaSeleccionado))
        {
            eMedico.Horario = JsonConvert.SerializeObject(dias);
            Session["usuario"] = eMedico;
            DBHorario.actualizarHorario(eMedico);
        }
        else
        {
            string script = @"<script type='text/javascript'> alert('Se cruza el horario'); </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        actualizarVistaDeHorario();
    }

    protected void actualizarVistaDeHorario()
    {
        EMedico eMedico = (EMedico)Session["usuario"];
        List<Dia> dias = JsonConvert.DeserializeObject<List<Dia>>(eMedico.Horario);

        String[] semana = {"", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"};

        P_Contenedor.Controls.Clear();

        foreach (Dia dia in dias)
        {
            Panel panelDia = new Panel();
            panelDia.CssClass = "P_Dia";

            Label lbDia = new Label();
            lbDia.Text = semana[dia.DiaSemana];
            lbDia.CssClass = "LB_Dia";

            panelDia.Controls.Add(lbDia);

            foreach (Rango rango in dia.Rangos)
            {
                Panel panelRangos = new Panel();
                panelRangos.CssClass = "P_Rangos";

                Label lbInicio = new Label();
                lbInicio.CssClass = "LB_Inicio";
                lbInicio.Text = "De: "+DateTime.Parse(rango.Inicio).ToShortTimeString();

                Label lbFin = new Label();
                lbFin.CssClass = "LB_Fin";
                lbFin.Text = "A: " + DateTime.Parse(rango.Fin).ToShortTimeString();

                Button btnEliminar = new Button();
                btnEliminar.CssClass = "BTN_Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.CommandName = "{ 'Dia':"+dia.DiaSemana+", 'Rango':"+JsonConvert.SerializeObject(rango)+"}";
                btnEliminar.Click += new System.EventHandler(this.btn_Click);

                panelRangos.Controls.Add(lbInicio);
                panelRangos.Controls.Add(lbFin);
                panelRangos.Controls.Add(btnEliminar);

                panelDia.Controls.Add(panelRangos);
            }
            P_Contenedor.Controls.Add(panelDia);
        }
    }

    private void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        JObject jObject = JObject.Parse(btn.CommandName);

        EMedico eMedico = (EMedico)Session["usuario"];
        List<Dia> dias = JsonConvert.DeserializeObject<List<Dia>>(eMedico.Horario);
        Rango rango = JsonConvert.DeserializeObject<Rango>((jObject.Value<JObject>("Rango")).ToString());

        GestorHorario.eliminarRango(jObject.Value<int>("Dia"), rango, dias);

        eMedico.Horario = JsonConvert.SerializeObject(dias);
        Session["usuario"] = eMedico;
        DBHorario.actualizarHorario(eMedico);

        string script = @"<script type='text/javascript'> console.log('Vacio'); </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        Response.Redirect("~/View/Medico/HorarioTrabajoPrueba.aspx");
    }

}