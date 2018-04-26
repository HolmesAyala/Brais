using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_HorarioTrabajo : System.Web.UI.Page
{
    bool validate=true;
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
    //METODO PARA INSERTAR POR PRIMERA VEZ UN RANGO DE UN DIA NUEVO
    private void insertarFirst()
    {
        EDia[] dia = new EDia[1];
        dia[0] = new EDia();
        dia[0].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
        dia[0].Hora_fin = DL_hora_fin.SelectedItem.ToString();
        dia[0].Dia = DL_dias.SelectedItem.ToString();
        validarRango(DL_hora_inicial.SelectedItem.ToString(), DL_hora_fin.SelectedItem.ToString());
        if (validate)
        {
            Session["rang"] = dia;
            Session["ant_day"] = DL_dias.SelectedItem.ToString();
            String ayu = JsonConvert.SerializeObject(dia);
            dias_escogidos.Text = ayu;
        }
    }


    //METODO PARA INSERTAR UN RANGO EN EL DIA SELECCIONADO
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DL_hora_inicial.SelectedItem.ToString()== "---------"||DL_hora_fin.SelectedItem.ToString()== "---------")
        {
            ClientScriptManager cm = this.ClientScript;
            String dato = "<script type='text/javascript'>alert('Debe Seleccionar Un Dato Para La H.inicial y H.final')</script>;";
            cm.RegisterClientScriptBlock(this.GetType(), "", dato);
        }
        else if (Session["rang"] == null){
            insertarFirst();
            }
            else 
            {
                if ((String)Session["ant_day"]!= DL_dias.SelectedItem.ToString())
                {
                    Session["rang"] = null;
                    insertarFirst();
                }
                else
                {
                    insertar_after();
                }
            }
    }
    //INSERTAR RANGO CUANDO HAY MAS DE 1
    private void insertar_after()
    {
        EDia[] aux = (EDia[])Session["rang"];
        EDia[] dias = new EDia[aux.Length + 1];
        for (int i = 0; i < aux.Length; i++)
        {
            dias[i] = aux[i];
        }
        dias[aux.Length] = new EDia();
        dias[aux.Length].Hora_inicio = DL_hora_inicial.SelectedItem.ToString();
        dias[aux.Length].Hora_fin = DL_hora_fin.SelectedItem.ToString();
        dias[aux.Length].Dia = DL_dias.SelectedItem.ToString();
        validarRango(DL_hora_inicial.SelectedItem.ToString(), DL_hora_fin.SelectedItem.ToString());
        if (validate)
        {
            Session["rang"] = dias;
            String ayu = JsonConvert.SerializeObject(dias);
            dias_escogidos.Text = ayu;
        }
    }

    //VALIDAR RANGO INSERTADO
    private void validarRango(String inicio,String fin)
    {
        int va_inicio = DateTime.Parse(inicio).Hour;
        int va_fin = DateTime.Parse(fin).Hour;
        EDia[] rang = (EDia [])Session["rang"];
        ClientScriptManager cm = this.ClientScript;
        if (va_inicio > va_fin)
        {
            //ERROR
            String dato = "<script type='text/javascript'>alert('El Rango Insertado No es Valido')</script>;";
            cm.RegisterClientScriptBlock(this.GetType(), "", dato);
            validate = false;
        }
        else
        {
            if (Session["rang"] != null)
            {
                for (int i = 0; i < rang.Length; i++)
                {
                    int va_in_old = DateTime.Parse(rang[i].Hora_inicio).Hour;
                    int va_fi_old = DateTime.Parse(rang[i].Hora_fin).Hour;
                    if (va_fi_old > va_inicio)
                    {
                        //ERROR
                        String dato = "<script type='text/javascript'>alert('El Rango Insertado Ya Se Encuentra en Otro Rango')</script>;";
                        cm.RegisterClientScriptBlock(this.GetType(), "", dato);
                        validate = false;
                    }
                    else
                    {
                        
                    }
                }
            }
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