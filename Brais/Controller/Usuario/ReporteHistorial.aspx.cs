using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Usuario;

public partial class View_Usuario_ReporteHistorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LHistorial lHistorial = new LHistorial();
            List<ReporteHistorialMedico> reporteHistorialMedicos = lHistorial.cargarInformeHistorial(Session["usuario"]);
            CRS_Historial.ReportDocument.SetDataSource(reporteHistorialMedicos);
            CRV_Historial.ReportSource = CRS_Historial;
        }
        catch (Exception)
        {
            throw;
        }
    }
}