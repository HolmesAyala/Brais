using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_Administrador_Reporte_Medicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            InfoMedicos reporte = ObtenerInforme();
            CR_medicos.ReportDocument.SetDataSource(reporte);
            CrystalReportViewer1.ReportSource = CR_medicos;
        }catch(Exception ex)
        {
            throw ex;
        }
    }

    protected InfoMedicos ObtenerInforme()
    {
        DataRow fila;
        DataTable inf_medc = new DataTable();
        InfoMedicos datos = new InfoMedicos();
        inf_medc = datos.Tables["Medico"];
        DBMedico dbme = new DBMedico();
        DataTable intermedio = dbme.buscarMedico("");
        for(int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = inf_medc.NewRow();
            fila["identificacion"] = intermedio.Rows[i]["identificacion"].ToString();
            fila["nombre"] = intermedio.Rows[i]["nombre"].ToString();
            fila["apellido"] = intermedio.Rows[i]["apellido"].ToString();
            fila["correo"] = intermedio.Rows[i]["correo"].ToString();
            inf_medc.Rows.Add(fila);
        }
        return datos;


    }



    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}