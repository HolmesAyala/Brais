using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_ReporteHistorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HistorialMedico reporte = ObtenerInforme();
            CRS_Historial.ReportDocument.SetDataSource(reporte);
            CRV_Historial.ReportSource = CRS_Historial;
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected HistorialMedico ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacionHistorial = new DataTable(); //dt
        HistorialMedico datos = new HistorialMedico();

        informacionHistorial = datos.Tables["Historial"];
        DBHistorial dBHistorial = new DBHistorial();

        EUsuario eUsuario = new EUsuario();
        eUsuario = (EUsuario)Session["usuario"];

        DataTable intermedio = dBHistorial.obtenerHistorial(eUsuario.Identificacion);

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacionHistorial.NewRow();

            DateTime fecha = new DateTime();
            fecha = DateTime.Parse(intermedio.Rows[i]["fecha"].ToString());
            fila["Fecha"] = Convert.ToString(fecha.ToShortDateString());
            if (intermedio.Rows[i]["motivo_consulta"].ToString().Equals(""))
            {
                fila["Motivo Consulta"] = "No especifica";
            } 
            fila["Observación"] = intermedio.Rows[i]["observacion"].ToString();
            fila["Especialidad"] = intermedio.Rows[i]["servicio"].ToString();
            fila["Médico"] = intermedio.Rows[i]["nombre_medico"].ToString();

            informacionHistorial.Rows.Add(fila);
        }

        return datos;
    }
}