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
        Historial_Citas reporte = ObtenerInforme();
        CRS_historial_user.ReportDocument.SetDataSource(reporte);
        CrystalReportViewer1.ReportSource = CRS_historial_user;

    }

    protected Historial_Citas ObtenerInforme()
    {
        DataRow fila;
        DataTable inf_medc = new DataTable();
        Historial_Citas datos = new Historial_Citas();
        inf_medc = datos.Tables["Historial"];
        DBCita db_user = new DBCita();
        EUsuario eUsuario = (EUsuario)Session["Usuario"];
        DataTable intermedio = db_user.obtener_all_cites(eUsuario.Identificacion);
        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = inf_medc.NewRow();
            fila["Fecha"] = intermedio.Rows[i]["dia"].ToString();
            fila["Hora Inicio"] = intermedio.Rows[i]["hora_inicio"].ToString();
            fila["Hora Fin"] = intermedio.Rows[i]["hora_fin"].ToString();
            fila["Pago"] = intermedio.Rows[i]["pago"].ToString();
            inf_medc.Rows.Add(fila);
        }
        return datos;


    }
}