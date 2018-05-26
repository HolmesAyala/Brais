using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_VerMedicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerDatosMedico("");
    }

    protected void obtenerDatosMedico(string id)
    {
        DBMedico dBMedico = new DBMedico();
        GV_Medicos.DataSource = dBMedico.buscarMedico(id);
        GV_Medicos.DataBind();
    }

    protected void BTN_Buscar_Click(object sender, EventArgs e)
    {
        obtenerDatosMedico(TB_Buscar.Text.Trim());
    }

    protected void BTN_Modificar_Click(object sender, EventArgs e)
    {
        Button btnModificar = (Button)sender;
        Session["Accion"] = "Actualizar";
        Session["identificacion_medico"] = btnModificar.CommandName;
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Medico/InsertarEliminarActualizar.aspx");
    }

    protected void BTN_Eliminar_Click(object sender, EventArgs e)
    {
        Button btnEliminar = (Button)sender;
        DBMedico dBMedico = new DBMedico();
        DBConsultorio dBConsultorio = new DBConsultorio();
        DataTable medico = dBMedico.obtenerMedico(btnEliminar.CommandName);
        dBMedico.eliminarMedico(btnEliminar.CommandName, Session.SessionID);
        obtenerDatosMedico("");
        dBConsultorio.liberarDisponibilidad(int.Parse(medico.Rows[0]["consultorio_pk"].ToString()), Session.SessionID);
    }

    protected void BTN_AgregarMedico_Click(object sender, EventArgs e)
    {
        Session["Accion"] = "Insertar";
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Medico/InsertarEliminarActualizar.aspx");
    }

    protected void GV_Medicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Medicos.PageIndex = e.NewPageIndex;
        obtenerDatosMedico("");
    }

    protected void BTN_Reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/Reporte_Medicos.aspx");
    }
}