using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Medico;

public partial class View_Medico_ReporteCitas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LCita lCita = new LCita();
            List<ReporteCita> reporteCitas = new List<ReporteCita>();
            reporteCitas = lCita.cargarInformeCitas(Session["identificacion_medico"]);
            CRS_Pacientes.ReportDocument.SetDataSource(reporteCitas);
            CRV_Pacientes.ReportSource = CRS_Pacientes;
        }
        catch (Exception)
        {
            throw;
        }
    }
}