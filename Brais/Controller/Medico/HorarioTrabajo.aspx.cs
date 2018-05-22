using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_HorarioTrabajo : System.Web.UI.Page
{
    bool validate=true;
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        //WE LOAD THE DATA OF DB IN THE GRIDVIEW BUT BEFORE I HAVE TO EDIT THE VALUES FOR SOME MORE ORGANIZED
        pintar_schedule();
    }

    private void pintar_schedule()
    {
        DBMedico bdM = new DBMedico();
        DataTable data = new DataTable();
        data = bdM.get_schedule((String)Session["identificacion_medico"]);
        if (data.Rows.Count > 0)
        {
            EDia[] Lun, mar, mier, juev, vier, sab = null;
            ESemana sem;
            sem = JsonConvert.DeserializeObject<ESemana>(data.Rows[0]["horario"].ToString());
            List<String> horar = new List<string>();
            if (sem.Lunes != null)
            {
                text_Lunes.Text = "Lunes";
                Lun = new EDia[sem.Lunes.Count];
                String aux = "";
                for (int i = 0; i < sem.Lunes.Count; i++)
                {
                    Lun[i] = JsonConvert.DeserializeObject<EDia>(sem.Lunes.ElementAt<String>(i));
                    aux = aux + Lun[i].Hora_inicio + "-" + Lun[i].Hora_fin + "</br>";
                }
                this.Lun.Text = aux;
            }
            if (sem.Martes != null)
            {
                text_Martes.Text = "Martes";
                mar = new EDia[sem.Martes.Count];
                String aux = "";
                for (int i = 0; i < mar.Length; i++)
                {
                    mar[i] = JsonConvert.DeserializeObject<EDia>(sem.Martes.ElementAt<String>(i));
                    aux = aux + mar[i].Hora_inicio + "-" + mar[i].Hora_fin + "</br>";
                }
                this.Mar.Text = aux;
            }
            if (sem.Miercoles != null)
            {
                text_Mercoles.Text = "Miercoles";
                mier = new EDia[sem.Miercoles.Count];
                String aux = "";
                for (int i = 0; i < mier.Length; i++)
                {
                    mier[i] = JsonConvert.DeserializeObject<EDia>(sem.Miercoles.ElementAt<String>(i));
                    aux = aux + mier[i].Hora_inicio + "-" + mier[i].Hora_fin + "</br>";
                }
                this.Mier.Text = aux;

            }
            if (sem.Jueves != null)
            {
                juev = new EDia[sem.Jueves.Count];
                String aux = "";
                text_Jueves.Text = "Jueves";
                for (int i = 0; i < juev.Length; i++)
                {
                    juev[i] = JsonConvert.DeserializeObject<EDia>(sem.Jueves.ElementAt<String>(i));
                    aux = aux + juev[i].Hora_inicio + "-" + juev[i].Hora_fin + "</br>";
                }
                this.Juev.Text = aux;
            }
            if (sem.Viernes != null)
            {
                text_viernes.Text = "Viernes";
                String aux = "";
                vier = new EDia[sem.Viernes.Count];
                for (int i = 0; i < vier.Length; i++)
                {
                    vier[i] = JsonConvert.DeserializeObject<EDia>(sem.Viernes.ElementAt<String>(i));
                    aux = aux + vier[i].Hora_inicio + "-" + vier[i].Hora_fin + "</br>";
                }
                this.Vier.Text = aux;
            }
            if (sem.Sabado != null)
            {
                sab = new EDia[sem.Sabado.Count];
                String aux = "";
                for (int i = 0; i < sab.Length; i++)
                {
                    sab[i] = JsonConvert.DeserializeObject<EDia>(sem.Sabado.ElementAt<String>(i));
                    aux = aux + sab[i].Hora_inicio + "-" + sab[i].Hora_fin + "</br>";
                }
            }

        }
        else
        {
            LB_nohay.Text = "No Hay Creado Su Horario De Trabajo";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Semana"] != null)
        {
            DBMedico medicdb = new DBMedico();
            EMedico medic = new EMedico();
            String horario_full = JsonConvert.SerializeObject((ESemana)Session["semana"]);
           
          
            medic.Horario = horario_full;
            medic.Identificacion = (String)Session["identificacion_medico"];
            medicdb.crear_horario(medic);
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
        String pinta_horar;
        pinta_horar = "";
        ESemana semana =(ESemana) Session["semana"];
        if (semana.Lunes != null)
        {
            pinta_horar = pinta_horar + "LUNES";
            for (int i = 0; i < semana.Lunes.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Lunes.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }if (semana.Martes != null)
        {
            pinta_horar = pinta_horar + "MARTES";
            for (int i = 0; i < semana.Martes.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Martes.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }
        if (semana.Miercoles !=null)
        {
            pinta_horar = pinta_horar + "MIERCOLES";
            for (int i = 0; i < semana.Miercoles.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Miercoles.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }
        if (semana.Jueves != null)
        {
            pinta_horar = pinta_horar + "JUEVES";
            for (int i = 0; i < semana.Jueves.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Jueves.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }
        if (semana.Viernes != null)
        {
            pinta_horar = pinta_horar + "VIERNES";
            for (int i = 0; i < semana.Viernes.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Viernes.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }
        if (semana.Sabado != null)
        {
            pinta_horar = pinta_horar + "SABADO";
            for (int i = 0; i < semana.Sabado.Count; i++)
            {
                pinta_horar = pinta_horar + "</br>" + obtener_hora(semana.Sabado.ElementAt(i));
            }
            pinta_horar = pinta_horar + "</br></br>";
        }
        dias_escogidos.Text = pinta_horar;
       
    }

    private String obtener_hora(String dia)
    {
        String res="";
        EDia day=JsonConvert.DeserializeObject<EDia>(dia);
        res = res + day.Hora_inicio+"-"+day.Hora_fin;
        return res;
    }

    private String recorrer_dia(EDia [] day)
    {
        String final = "";
        for (int i = 0; i < day.Length; i++)
        {
            final = final + "</br>" + day[i].Hora_inicio + " " + day[i].Hora_fin + "</br>";
        }
        return final;
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
        Session["rang"] = null;
        //SE EVALUA EL DIA CON EL FIN DE CREAR LA ACTIVIDAD SEMANAL DEL MEDICO
        if (day != null)
        {
            switch (DL_dias.SelectedItem.ToString())
            {
                case "Lunes":
                    for (int i = 0; i < day.Length; i++)
                    {
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        if (seman.Lunes==null)seman.crear_lunes();
                        seman.Lunes.Add(aux);
                    }
                    break;
                case "Martes":
                    for (int i = 0; i < day.Length; i++)
                    {
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        if (seman.Martes==null)seman.crear_Martes();
                        seman.Martes.Add(aux);
                    }
                    break;
                case "Miercoles":
                    for (int i = 0; i < day.Length; i++)
                    {
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        if (seman.Miercoles==null)seman.crear_Miercoles();
                        seman.Miercoles.Add(aux);
                    }
                    break;
                case "Jueves":
                    for (int i = 0; i < day.Length; i++)
                    {
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        if (seman.Jueves==null)seman.crear_Jueves();
                        seman.Jueves.Add(aux);
                    }
                    break;
                case "Viernes":
                    for (int i = 0; i < day.Length; i++)
                    {
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        if (seman.Viernes==null)seman.crear_Viernes();
                        seman.Viernes.Add(aux);
                    }
                    break;
                case "Sabado":
                    for (int i = 0; i < day.Length; i++)
                    {
                        if (seman.Sabado==null)seman.crear_Sabado();
                        String aux = JsonConvert.SerializeObject((EDia)day[i]);
                        seman.Sabado.Add(aux);
                    }
                    break;
            }
            Session["semana"] = seman;
            mostrar_datos();
        }
    }


    private String crear_cadena_dias(EDia [] dias)
    {
        String cadena = "";
        for (int i = 0; i < dias.Length; i++)
        {
            cadena=cadena+dias[i].Hora_inicio+"-";
            cadena = cadena + dias[i].Hora_fin + "</br>";
        }
        return cadena;
    }

    private EDia[] llenar_eDias(String[] json)
    {
        List<EDia> day= new List<EDia>(); 
        for (int i = 0; i < json.Length; i++)
        {
            EDia aux=JsonConvert.DeserializeObject<EDia>(json[i]);
            day.Add(aux);    
        }
        return day.ToArray();
    }

    protected void mostrar_datos()
    {
        String dias="";
        ESemana sem=(ESemana)Session["semana"];
        if (sem.Lunes != null)
        {
            dias=dias+" Lunes "+"</br>";
            String [] d  = sem.Lunes.ToArray();
            EDia [] di= llenar_eDias(d);
            dias = dias + crear_cadena_dias(di)+ "</br>";
        }
        if (sem.Martes != null)
        {
            dias = dias + " Martes " + "</br>";
            String[] d = sem.Martes.ToArray();
            EDia[] di = llenar_eDias(d);
            dias = dias + crear_cadena_dias(di) + "</br>";
        }
        if (sem.Miercoles != null)
        {
            dias = dias + " Miercoles "+"</br>";
            String[] d = sem.Miercoles.ToArray();
            EDia[] di = llenar_eDias(d);
            dias = dias + crear_cadena_dias(di) + "</br>";
        }
        if (sem.Jueves != null)
        {
            dias = dias + " Jueves "+"</br>";
            String[] d = sem.Jueves.ToArray();
            EDia[] di = llenar_eDias(d);
            dias = dias + crear_cadena_dias(di) + "</br>";
        }
        if (sem.Viernes != null)
        {
            dias = dias + " Viernes "+"</br>";
            String[] d = sem.Viernes.ToArray();
            EDia[] di = llenar_eDias(d);
            dias = dias + crear_cadena_dias(di) + "</br>";
        }
        if (sem.Sabado != null)
        {
            dias = dias + " Sabado "+"</br>";
            String[] d = sem.Sabado.ToArray();
            EDia[] di = llenar_eDias(d);
            dias = dias + crear_cadena_dias(di) + "</br>";
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
            pintar_rango(dia);

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
            pintar_rango(dias);
        }
    }

    private void pintar_rango(EDia [] dias) {
        String cadena="";
        for (int i = 0; i < dias.Length; i++)
        {
            cadena = cadena + dias[i].Hora_inicio+"-";
            cadena = cadena + dias[i].Hora_fin + "</br>";
        }
        dias_escogidos.Text = cadena;
    }


    //VALIDAR RANGO INSERTADO
    private void validarRango(String inicio,String fin)
    {
        int va_inicio = DateTime.Parse(inicio).Hour;
        int va_fin = DateTime.Parse(fin).Hour;
        EDia[] rang = (EDia [])Session["rang"];
        ClientScriptManager cm = this.ClientScript;
        if (va_inicio >= va_fin)
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
                    if (va_inicio == va_fin)
                    {
                        String dato = "<script type='text/javascript'>alert('El Rango Insertado No Es Valido')</script>;";
                        cm.RegisterClientScriptBlock(this.GetType(), "", dato);
                        validate = false;
                    }
                    if (va_fi_old > va_inicio)
                    {
                        if (va_inicio < va_in_old)
                        {
                            if (va_fin >= va_fi_old)
                            {
                                String dato = "<script type='text/javascript'>alert('El Rango Insertado Ya Se Encuentra en Otro Rango')</script>;";
                                cm.RegisterClientScriptBlock(this.GetType(), "", dato);
                                validate = false;
                            }
                        }
                        else
                        {
                            //ERROR
                            String dato = "<script type='text/javascript'>alert('El Rango Insertado Ya Se Encuentra en Otro Rango')</script>;";
                            cm.RegisterClientScriptBlock(this.GetType(), "", dato);
                            validate = false;
                        }
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

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("horario_medico.aspx");
    }
}