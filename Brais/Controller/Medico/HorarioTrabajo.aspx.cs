using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_HorarioTrabajo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ESemana seman;
        if (Session["semana"] == null)
        {
             seman = new ESemana();
        }
        else
        {
            seman = (ESemana)Session["semana"];
        }
        EDia[] day = (EDia [])Session["rang"];
        String aux= JsonConvert.SerializeObject(day);
        Session["rang"] = null;
        //SE EVALUA EL DIA CON EL FIN DE CREAR LA ACTIVIDAD SEMANAL DEL MEDICO
        switch (DL_dias.SelectedItem.ToString())
        {
            case "Lunes":
                seman.Lunes = aux;
                break;
            case "Martes":
                seman.Martes = aux;
                break;
            case "Miercoles":
                seman.Miercoles = aux;
                break;
            case "Jueves":
                seman.Jueves = aux;
                break;
            case "Viernes":
                seman.Viernes = aux;
                break;
            case "Sabado":
                seman.Sabado = aux;
                break;
        }
        Session["semana"] = seman;
        mostrar_datos();

    }

    public void mostrar_datos()
    {
        String dias="";
        ESemana sem=(ESemana)Session["semana"];
        if (sem.Lunes != null)
        {
            dias=dias+" Lunes ";
            dias = dias + Environment.NewLine + "</br>" + sem.Lunes+ "</br>";
        }
        if (sem.Martes != null)
        {
            dias=dias+" Martes ";
            dias = dias + Environment.NewLine + "</br>" + sem.Martes + "</br>";
        }
        if (sem.Miercoles != null)
        {
            dias = dias + " Miercoles ";
            dias = dias + Environment.NewLine + "</br>" + sem.Miercoles + "</br>";
        }
        if (sem.Jueves != null)
        {
            dias = dias + " Jueves ";
            dias = dias + Environment.NewLine +"</br>"+ sem.Jueves + "</br>";
        }
        if (sem.Viernes != null)
        {
            dias = dias + " Viernes ";
            dias = dias + Environment.NewLine + "</br>" + sem.Viernes + "</br>";
        }
        if (sem.Sabado != null)
        {
            dias = dias + " Sabado ";
            dias = dias + Environment.NewLine + "</br>" + sem.Sabado + "</br>";
        }
        dias_escogidos.Text = dias;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["rang"] == null)
        {
            EDia []dia = new EDia[1];
            dia[0] = new EDia();
            dia[0].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
            dia[0].Hora_fin = DL_hora_fin.SelectedItem.ToString();
            dia[0].Dia = DL_dias.SelectedItem.ToString();
            Session["rang"] = dia;
            String ayu = JsonConvert.SerializeObject(dia);
            dias_escogidos.Text = ayu;
        }
        else
        {
            EDia [] aux = (EDia[])Session["rang"];
            EDia [] dias = new  EDia[aux.Length+1];
            for (int i = 0; i < aux.Length; i++)
            {
                dias[i] = aux[i];
            }
            dias[aux.Length] = new EDia();
            dias[aux.Length].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
            dias[aux.Length].Hora_fin = DL_hora_fin.SelectedItem.ToString();
            dias[aux.Length].Dia = DL_dias.SelectedItem.ToString();
            Session["rang"] = dias;
            String ayu= JsonConvert.SerializeObject(dias);
            dias_escogidos.Text = ayu;
        }
        


    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        String delete_day = DL_deleteDay.SelectedItem.ToString();
        if (Session["semana"] != null)
        {
            ESemana sem = (ESemana)Session["semana"];
            switch (delete_day)
            {
                case "Lunes":
                    sem.Lunes = null;
                    break;
                case "Martes":
                    sem.Martes = null;
                    break;
                case "Miercoles":
                    sem.Miercoles = null;
                    break;
                case "Jueves":
                    sem.Jueves = null;
                    break;
                case "Viernes":
                    sem.Viernes = null;
                    break;
            }
            Session["semana"] = sem;
            mostrar_datos();
        }
    }
}