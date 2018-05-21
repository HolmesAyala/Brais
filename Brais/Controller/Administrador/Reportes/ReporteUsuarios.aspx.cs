using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_ReporteUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            InfoUsuarios reporte = ObtenerInforme();
            CRS_Usuarios.ReportDocument.SetDataSource(reporte);
            CRV_Usuarios.ReportSource = CRS_Usuarios;
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected InfoUsuarios ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacionUsuarios = new DataTable(); //dt
        InfoUsuarios datos = new InfoUsuarios();

        informacionUsuarios = datos.Tables["Usuario"];
        DBUsuario dBUsuario = new DBUsuario();

        DataTable intermedio = dBUsuario.buscarUsuario("");

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacionUsuarios.NewRow();

            fila["Identificación"] = intermedio.Rows[i]["identificacion"].ToString();
            if (intermedio.Rows[i]["nombre_identificacion"].ToString().Equals("Cedula"))
            {
                fila["Tipo"] = "C.C";
            }
            else if (intermedio.Rows[i]["nombre_identificacion"].ToString().Equals("Tarjeta de identidad"))
            {
                fila["Tipo"] = "T.I";
            }
            fila["Nombre"] = intermedio.Rows[i]["nombre"].ToString();
            fila["Apellido"] = intermedio.Rows[i]["apellido"].ToString();
            fila["Afiliación"] = intermedio.Rows[i]["nombre_afiliacion"].ToString();
            fila["Correo"] = intermedio.Rows[i]["correo"].ToString();

            informacionUsuarios.Rows.Add(fila);
        }

        return datos;
    }
}