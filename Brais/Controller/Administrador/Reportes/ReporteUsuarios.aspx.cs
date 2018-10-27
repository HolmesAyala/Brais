using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data.Clases.Usuario;
using Logica.Clases.Administrador;
using Utilitaria.Clases.Administrador;

public partial class View_Administrador_ReporteUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<ReporteUsuario> reporteUsuarios = new List<ReporteUsuario>();
            LAdministrador lAdministrador = new LAdministrador();
            reporteUsuarios = lAdministrador.cargarInformeUsuarios(); ;
            CRS_Usuarios.ReportDocument.SetDataSource(reporteUsuarios);
            CRV_Usuarios.ReportSource = CRS_Usuarios;
        }
        catch (Exception)
        {
            throw;
        }
    }
}