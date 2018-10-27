using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Data.Clases.Medico;
using Logica.Clases.Administrador;
using Utilitaria.Clases.Administrador;

public partial class View_Administrador_Reporte_Medicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            LAdministrador lAdministrador = new LAdministrador();
            List<ReporteMedico> reporteMedicos = lAdministrador.cargarReporteMedicos();
            CR_medicos.ReportDocument.SetDataSource(reporteMedicos);
            CrystalReportViewer1.ReportSource = CR_medicos;
        }catch(Exception ex)
        {
            throw ex;
        }
    }

    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}