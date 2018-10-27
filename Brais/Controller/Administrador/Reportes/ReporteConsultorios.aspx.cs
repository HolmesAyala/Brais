using Logica.Clases.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Administrador;


public partial class View_Administrador_ReporteConsultorios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LConsultorio lConsultorio = new LConsultorio();
            List<ReporteConsultorios> reporteConsultorios = lConsultorio.cargarInformeConsultorios(); ;
            CRS_Consultorios.ReportDocument.SetDataSource(reporteConsultorios);
            CRV_Consultorios.ReportSource = CRS_Consultorios;
        }
        catch (Exception)
        {
            throw;
        }
    }
}