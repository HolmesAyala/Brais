using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_CancelarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitasPaciente();
    }

    protected void obtenerCitasPaciente()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DBCita dBCita = new DBCita();
        GV_Cancelar_Cita.DataSource = dBCita.obtenerCitasPaciente(eUsuario.Identificacion);
        GV_Cancelar_Cita.DataBind();
    }


    protected void GV_Cancelar_Cita_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Cancelar_Cita.PageIndex = e.NewPageIndex;
        obtenerCitasPaciente();
    }

    protected void BTN_Seleccionar_Click(object sender, EventArgs e)
    {
        Button btnSeleccionar = (Button)sender;
        DBUsuario dBUsuario = new DBUsuario();
        ECita eCita = new ECita();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        eCita.Id = Convert.ToInt32(btnSeleccionar.CommandName);
        eCita.EUsuario = eUsuario;
        DBCita.eliminarCita(eCita);
        obtenerCitasPaciente();
    }
}