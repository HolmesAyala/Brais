using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_AsignarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void C_FechasDisponibles_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = validarFecha(e.Day.Date);
        if (e.Day.IsSelectable)
        {
            e.Cell.BorderColor = Color.Red;
            e.Cell.BorderStyle = BorderStyle.Ridge;
            e.Cell.BorderWidth = 1;
        }

    }

    protected Boolean validarFecha(DateTime dateTime)
    {
        string[] fechas = new string[] { "2018-04-23", "2018-04-24", "2018-04-25", "2018-04-26" };
        foreach (string fecha in fechas)
        {
            if (dateTime == DateTime.Parse(fecha))
            {
                return true;
            }
        }
        return false;
    }

}