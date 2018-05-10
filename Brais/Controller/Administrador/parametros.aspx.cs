using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_parametros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void llenarGridView()
    {
        DBAdministrador admin = new DBAdministrador(); 
        GV_consultorios.DataSource = admin.obtenerConsultorios();
        GV_consultorios.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DBAdministrador admin = new DBAdministrador();
        EConsultorio consul = new EConsultorio();
        consul.Nombre = TB_Consultorio.Text;
        consul.Ubicacion = TB_Ubicacion.Text;
        consul.Session = Session.SessionID;
        admin.insertarConsultorio(consul);
        Response.Redirect("parametros.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id;
        id=btn.CommandArgument.ToString();
        Session["id"] = id;
        Response.Redirect("editar_consultorio.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id;
        id = btn.CommandArgument.ToString();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int fk_parametro =int.Parse(DL_tiempo.SelectedItem.Value);
        DBAdministrador admin = new DBAdministrador();
        admin.actualizar_param(fk_parametro);
        ClientScriptManager cm = this.ClientScript;
        String dato = "<script type='text/javascript'>alert('A Partir de este momento las citas van a durar "+DL_tiempo.SelectedItem+" minutos')</script>;";
        cm.RegisterClientScriptBlock(this.GetType(), "", dato);
    }

    protected void BTN_Reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/ReporteConsultorios.aspx");

    }
}