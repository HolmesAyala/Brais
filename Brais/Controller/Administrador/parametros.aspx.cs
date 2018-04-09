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

    }
}