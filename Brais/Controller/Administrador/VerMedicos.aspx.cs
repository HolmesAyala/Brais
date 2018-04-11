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
        Label lbModificar = (Label)btnModificar.Parent.Controls[1];
        Session["Accion"] = "Actualizar";
        Session["identificacion"] = lbModificar.Text;
        Session["PaginaAnterior"] = Request.Url.AbsoluteUri;
        Response.Redirect("~/View/Medico/InsertarEliminarActualizar.aspx");
    }

    protected void BTN_Eliminar_Click(object sender, EventArgs e)
    {

    }

    protected void BTN_AgregarMedico_Click(object sender, EventArgs e)
    {

    }

    protected void GV_Medicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Medicos.PageIndex = e.NewPageIndex;
        obtenerDatosMedico("");
    }
}