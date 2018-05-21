using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_Medico_horario_medico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            horario_medico reporte = ObtenerInforme();
            CR_horar_medic.ReportDocument.SetDataSource(reporte);
            CrystalReportViewer1.ReportSource = CR_horar_medic;
        }
        catch (Exception ex){
            throw ex;
        }
    }

    protected horario_medico ObtenerInforme()
    {
        DataRow fila;
        DataTable inf_medc = new DataTable();
        horario_medico datos = new horario_medico();
        inf_medc = datos.Tables["Horario"];
        DBMedico dbme = new DBMedico();
        DataTable intermedio = dbme.get_schedule_organized(Session["identificacion_medico"].ToString());
        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = inf_medc.NewRow();
            fila["lunes"] = intermedio.Rows[i]["lunes"].ToString();
            fila["martes"] = intermedio.Rows[i]["martes"].ToString();
            fila["miercoles"] = intermedio.Rows[i]["miercoles"].ToString();
            fila["jueves"] = intermedio.Rows[i]["jueves"].ToString();
            fila["viernes"] = intermedio.Rows[i]["viernes"].ToString();
            inf_medc.Rows.Add(fila);
        }
        dbme.delete_aux_schedule();
        return datos;


    }



}