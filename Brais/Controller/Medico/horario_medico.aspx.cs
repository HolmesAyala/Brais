using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica.Clases.Medico;
using Utilitaria.Clases.Medico;

public partial class View_Medico_horario_medico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LMedico lMedico = new LMedico();
            List<ReporteHorario> reporteHorarios = lMedico.cargarInformeHorario(Session["identificacion_medico"].ToString());

            CR_horar_medic.ReportDocument.SetDataSource(reporteHorarios);
            CrystalReportViewer1.ReportSource = CR_horar_medic;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}