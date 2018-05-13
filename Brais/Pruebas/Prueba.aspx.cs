using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pruebas_Prueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Dia dia = new Dia();
        dia.DiaSemana = (int)DateTime.Now.DayOfWeek;

        Rango rango = new Rango();
        rango.Inicio = DateTime.Parse("06:00:00").ToString("HH:mm:ss");
        rango.Fin = DateTime.Parse("07:00:00").ToString("HH:mm:ss");

        dia.Rangos.Add(rango);

        rango = new Rango();
        rango.Inicio = DateTime.Parse("09:00:00").ToString("HH:mm:ss");
        rango.Fin = DateTime.Parse("10:00:00").ToString("HH:mm:ss");

        dia.Rangos.Add(rango);

        rango = new Rango();
        rango.Inicio = DateTime.Parse("12:00:00").ToString("HH:mm:ss");
        rango.Fin = DateTime.Parse("14:00:00").ToString("HH:mm:ss");

        dia.Rangos.Add(rango);

        string json = JsonConvert.SerializeObject(dia);

        Dia dia2 = JsonConvert.DeserializeObject<Dia>(json);

        LB_Mensaje.Text = json;

        LB_Prueba.InnerText = dia2.Rangos.ToString();
    }
}