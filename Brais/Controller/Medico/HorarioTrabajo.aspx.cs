using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica.Clases.Medico;
using Utilitaria.Clases.Medico;
using Utilitaria.Clases.Administrador;

public partial class View_Medico_HorarioTrabajo : System.Web.UI.Page
{
    bool validate = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        //WE LOAD THE DATA OF DB IN THE GRIDVIEW BUT BEFORE I HAVE TO EDIT THE VALUES FOR SOME MORE ORGANIZED
        pintar_schedule();
    }

    private void pintar_schedule()
    {
        try
        {
            ReporteHorario reporteHorario = new ReporteHorario();
            LMedico lMedico = new LMedico();
            reporteHorario = lMedico.get_schedule((String)Session["identificacion_medico"]);

            this.Lun.Text = reporteHorario.Lunes;
            this.Mar.Text = reporteHorario.Martes;
            this.Mier.Text = reporteHorario.Miercoles;
            this.Juev.Text = reporteHorario.Jueves;
            this.Vier.Text = reporteHorario.Viernes;

        }
        catch (Exception ex)
        {
            LB_nohay.Text = ex.Message.ToString();
        }
        
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Semana"] != null)
        {
            LMedico lMedico = new LMedico();
            EMedico medic = new EMedico();
            String horario_full = JsonConvert.SerializeObject((ESemana)Session["semana"]);
           
          
            medic.Horario = horario_full;
            medic.Identificacion = (String)Session["identificacion_medico"];
            medic.Session = Session.SessionID;
            lMedico.crear_horario(medic);
            dias_escogidos.Text = horario_full;
            pintar_horario();
            Lun.Text = "";
            Mar.Text = "";
            Mier.Text = "";
            Juev.Text = "";
            Vier.Text = "";
            pintar_schedule();

        }
        else
        {
            ClientScriptManager cm = this.ClientScript;
            String dato = "<script type='text/javascript'>alert('Debe Por Lo Menos Haber Añadido un Dia Para Cambiar Su Horario')</script>;";
            cm.RegisterClientScriptBlock(this.GetType(), "", dato);
        }

    }

    protected void pintar_horario()
    {
        LMedico lMedico = new LMedico();
        String mensaje = lMedico.pintarHorarioMedico((ESemana)Session["semana"]);
        dias_escogidos.Text = mensaje;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ESemana eSemana = new ESemana();
        LMedico lMedico = new LMedico();
        eSemana = lMedico.validarSemana(Session["semana"]);

        EDia[] day = (EDia[])Session["rang"];
        Session["rang"] = null;

        eSemana = lMedico.crearActividadSemanal(day, DL_dias.SelectedItem.ToString(), eSemana);

        // SE EVALUA EL DIA CON EL FIN DE CREAR LA ACTIVIDAD SEMANAL DEL MEDICO
        Session["semana"] = eSemana;
        mostrar_datos();
    }

    protected void mostrar_datos()
    {
        LMedico lMedico = new LMedico();
        String dias = lMedico.mostrar_datos((ESemana)Session["semana"]);
        dias_escogidos.Text = dias;
    }

    //METODO PARA INSERTAR POR PRIMERA VEZ UN RANGO DE UN DIA NUEVO
    private void insertarFirst()
    {
        LMedico lMedico = new LMedico();
        EDia[] dia = new EDia[1];
        dia[0] = new EDia();
        dia[0].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
        dia[0].Hora_fin = DL_hora_fin.SelectedItem.ToString();
        dia[0].Dia = DL_dias.SelectedItem.ToString();
        validarRango(DL_hora_inicial.SelectedItem.ToString(), DL_hora_fin.SelectedItem.ToString());
        try
        {
            lMedico.validate(validate);
            Session["rang"] = dia;
            Session["ant_day"] = DL_dias.SelectedItem.ToString();
            String ayu = JsonConvert.SerializeObject(dia);
            dias_escogidos.Text = ayu;
            pintar_rango(dia);
        }
        catch (Exception ex) { }
    }


    //METODO PARA INSERTAR UN RANGO EN EL DIA SELECCIONADO
    protected void Button3_Click(object sender, EventArgs e)
    {
        LMedico lMedico = new LMedico();
        try
        {
            lMedico.validarDDL(DL_hora_inicial.SelectedItem.ToString(), DL_hora_fin.SelectedItem.ToString());
            try
            {
                lMedico.validarRango(Session["rang"]);
                insertarFirst();
            }
            catch (Exception ex)
            {
                try
                {
                    lMedico.validarDias((String)Session["ant_day"], DL_dias.SelectedItem.ToString());
                    Session["rang"] = null;
                    insertarFirst();
                }
                catch (Exception exc)
                {
                    insertar_after();
                }
            }

        }
        catch (Exception ex)
        {
            ClientScriptManager cm = this.ClientScript;
            String dato = "<script type='text/javascript'>alert('Debe Seleccionar Un Dato Para La H.inicial y H.final')</script>;";
            cm.RegisterClientScriptBlock(this.GetType(), "", dato);
        }
    }

    //INSERTAR RANGO CUANDO HAY MAS DE 1
    private void insertar_after()
    {
        LMedico lMedico = new LMedico();
        EDia[] aux = (EDia[])Session["rang"];
        EDia[] dias = new EDia[aux.Length + 1];
        dias = lMedico.insertar_after(aux, dias);

        dias[aux.Length] = new EDia();
        dias[aux.Length].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
        dias[aux.Length].Hora_fin = DL_hora_fin.SelectedItem.ToString();
        dias[aux.Length].Dia = DL_dias.SelectedItem.ToString();
        validarRango(DL_hora_inicial.SelectedItem.ToString(), DL_hora_fin.SelectedItem.ToString());

        try
        {
            lMedico.validate(validate);
            Session["rang"] = dias;
            String ayu = JsonConvert.SerializeObject(dias);
            dias_escogidos.Text = ayu;
            pintar_rango(dias);
        }
        catch(Exception ex)
        {

        }
    }

    private void pintar_rango(EDia [] dias) {
        LMedico lMedico = new LMedico();
        String cadena = lMedico.pintar_rango(dias);
        dias_escogidos.Text = cadena;
    }


    //VALIDAR RANGO INSERTADO
    private void validarRango(String inicio,String fin)
    {
        int va_inicio = DateTime.Parse(inicio).Hour;
        int va_fin = DateTime.Parse(fin).Hour;
        LMedico lMedico = new LMedico();
        EDia[] rang = (EDia [])Session["rang"];
        ClientScriptManager cm = this.ClientScript;
        try
        {
            lMedico.validarRango(va_inicio, va_fin, Session["rang"], rang);
        }
        catch (Exception ex)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", ex.Message.ToString()  );
            validate = false;
        }
        

    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        String delete_day = DL_deleteDay.SelectedItem.ToString();
        LMedico lMedico = new LMedico();
        ESemana eSemana = lMedico.eliminarDias(delete_day, Session["semana"]);
        Session["semana"] = eSemana;
        mostrar_datos();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("horario_medico.aspx");
    }
}