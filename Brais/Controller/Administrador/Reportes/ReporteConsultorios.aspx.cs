using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_ReporteConsultorios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            consultoriosRegistrados reporte = ObtenerInforme();
            CRS_Consultorios.ReportDocument.SetDataSource(reporte);
            CRV_Consultorios.ReportSource = CRS_Consultorios;
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected consultoriosRegistrados ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacionConsultorios = new DataTable(); //dt
        consultoriosRegistrados datos = new consultoriosRegistrados();

        informacionConsultorios = datos.Tables["Consultorio"];
        DBConsultorio dBConsultorio = new DBConsultorio();

        DataTable intermedio = dBConsultorio.obtenerConsultorios();

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacionConsultorios.NewRow();

            fila["Nombre"] = intermedio.Rows[i]["nombre_consultorio"].ToString();
            fila["Ubicación"] = intermedio.Rows[i]["ubicacion"].ToString();
            if (intermedio.Rows[i]["disponibilidad"].Equals(true))
            {
                fila["Disponible"] = "No";
            } else if (intermedio.Rows[i]["disponibilidad"].Equals(false) || intermedio.Rows[i]["disponibilidad"].Equals(null))
            {
                fila["Disponible"] = "Si";
            }

            informacionConsultorios.Rows.Add(fila);
        }

        return datos;
    }
}