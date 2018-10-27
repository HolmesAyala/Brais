using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica.Clases.Administrador;

public partial class View_Administrador_editar_consultorio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        llenarCampos(getConsultorio());

    }

    private DataTable getConsultorio()
    {
        int id = int.Parse(Session["id"].ToString());
        LAdministrador lAdministrador = new LAdministrador();
        DataTable consultorio = lAdministrador.obtenerConsultorio(id);
        return consultorio;
    }

    private void llenarCampos(DataTable consul)
    {
        TB_nombre.Text = consul.Rows[0]["nombre_consultorio"].ToString();
        TB_ubicacion.Text = consul.Rows[0]["ubicacion"].ToString();

    }

    protected void BTN_Enviar_Click(object sender, EventArgs e)
    {

    }
}