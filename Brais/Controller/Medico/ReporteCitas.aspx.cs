using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_ReporteCitas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            InfoPacientesCitas reporte = ObtenerInforme();
            CRS_Pacientes.ReportDocument.SetDataSource(reporte);
            CRV_Pacientes.ReportSource = CRS_Pacientes;
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected InfoPacientesCitas ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacionPacientes = new DataTable(); //dt
        InfoPacientesCitas datos = new InfoPacientesCitas();

        informacionPacientes = datos.Tables["Paciente"];
        DBUsuario dBUsuario = new DBUsuario();
        DataTable intermedio = new DataTable();
        if (Session["identificacion_medico"] != null)
        {
            intermedio = dBUsuario.obtenerPacientesAgendados((String)Session["identificacion_medico"]);
        }
        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacionPacientes.NewRow();

            fila["Hora"] = intermedio.Rows[i]["hora"].ToString();
            if (intermedio.Rows[i]["tipo_identificacion"].ToString().Equals("Cedula"))
            {
                fila["Tipo Identificación"] = "C.C";
            }
            else if (intermedio.Rows[i]["tipo_identificacion"].ToString().Equals("Tarjeta de identidad"))
            {
                fila["Tipo Identificación"] = "T.I";
            }
            fila["Identificación"] = intermedio.Rows[i]["identificacion"].ToString();
            fila["Nombre"] = intermedio.Rows[i]["nombre"].ToString();
            fila["Apellido"] = intermedio.Rows[i]["apellido"].ToString();

            informacionPacientes.Rows.Add(fila);
        }

        return datos;
    }
}