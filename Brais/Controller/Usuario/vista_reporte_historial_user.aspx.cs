using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_vista_reporte_historial_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LCita lCita = new LCita();
        List<ReporteHistorialCitas> reporteHistorialCitas = new List<ReporteHistorialCitas>();
        reporteHistorialCitas = lCita.carharReporteCitas(Session["Usuario"]);
        CRS_historial_user.ReportDocument.SetDataSource(reporteHistorialCitas);
        CrystalReportViewer1.ReportSource = CRS_historial_user;

    }
}