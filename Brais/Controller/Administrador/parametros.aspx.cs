using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_parametros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBAdministrador bd = new DBAdministrador();
        DataTable info = bd.param_actual();
        String value = info.Rows[0]["info"].ToString();
        if (info.Rows.Count > 0)
        {
            if (!IsPostBack)
            {

                DL_tiempo.SelectedValue= value;

            }
        }
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
        if ((TB_Consultorio.Text == "")||(TB_Consultorio.Text==""))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Nombre", "<script> alert('Ingrese los datos del consultorio a ingresar'); </script>");
        }
        else
        {
            consul.Nombre = TB_Consultorio.Text;
            consul.Ubicacion = TB_Ubicacion.Text;
            consul.Session = Session.SessionID;
            admin.insertarConsultorio(consul);
            Response.Redirect("parametros.aspx");
        }
        
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
        String sesion = Session.SessionID;
        admin.actualizar_param(fk_parametro,sesion);
        ClientScriptManager cm = this.ClientScript;
        String dato = "<script type='text/javascript'>alert('A Partir de este momento las citas van a durar "+DL_tiempo.SelectedItem+" minutos')</script>;";
        cm.RegisterClientScriptBlock(this.GetType(), "", dato);
    }

    protected void BTN_Reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Administrador/ReporteConsultorios.aspx");

    }

    protected void T_Especialidad_Tick(object sender, EventArgs e)
    {
        LB_MensajeEspecialidad.Text = "";
        T_Especialidad.Enabled = false;
    }

    protected void T_Eps_Tick(object sender, EventArgs e)
    {
        LB_MensajeEps.Text = "";
        T_Eps.Enabled = false;
    }

    protected void BTN_AgregarEspecialidad_Click(object sender, EventArgs e)
    {
        if (!TB_AgregarEspecialidad.Text.Trim().Equals(""))
        {
            Funcion.mostrarMensaje(TB_AgregarEspecialidad.Text, this);
            DBEspecialidad.agregarEspecialidad(TB_AgregarEspecialidad.Text.Trim(), Session.SessionID);
            TB_AgregarEspecialidad.Text = "";
            GV_Especialidad.DataBind();
            LB_MensajeEspecialidad.Text = "Agrego correctamente!";
        }
        else
        {
            LB_MensajeEspecialidad.Text = "Esta vacio!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_AgregarEps_Click(object sender, EventArgs e)
    {
        if (!TB_AgregarEps.Text.Trim().Equals(""))
        {
            Funcion.mostrarMensaje(TB_AgregarEps.Text, this);
            DBEps.agregarEps(TB_AgregarEps.Text.Trim(), Session.SessionID);
            TB_AgregarEps.Text = "";
            GV_Eps.DataBind();
            LB_MensajeEps.Text = "Agrego correctamente!";
        }
        else
        {
            LB_MensajeEps.Text = "Esta vacio!";
        }
        T_Eps.Enabled = true;
    }

    protected void BTN_ActualizarEspecialidad_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        TextBox tb = (TextBox)btn.Parent.FindControl("TB_Especialidad");

        if (!tb.Text.Trim().Equals(""))
        {
            DBEspecialidad.actualizarEspecialidad( int.Parse(btn.CommandName), tb.Text, Session.SessionID);
            LB_MensajeEspecialidad.Text = "Actualizo correctamente!";
            GV_Especialidad.DataBind();
        }
        else
        {
            LB_MensajeEspecialidad.Text = "El nombre que va a actualizar esta vacio!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_EliminarEspecialidad_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if ( !DBEspecialidad.hayUnMedicoConEstaEspecialidad(int.Parse(btn.CommandName)) ){
            DBEspecialidad.eliminarEspecialidad(int.Parse(btn.CommandName), Session.SessionID);
            LB_MensajeEspecialidad.Text = "Elimino correctamente!";
            GV_Especialidad.DataBind();
        }
        else
        {
            LB_MensajeEspecialidad.Text = "Hay medicos registrados con esa especialidad!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_ActualizarEps_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        TextBox tb = (TextBox)btn.Parent.FindControl("TB_Eps");

        if (!tb.Text.Trim().Equals(""))
        {
            DBEps.actualizarEps(int.Parse(btn.CommandName), tb.Text, Session.SessionID);
            LB_MensajeEps.Text = "Actualizo correctamente!";
            GV_Eps.DataBind();
        }
        else
        {
            LB_MensajeEps.Text = "El nombre que va a actualizar esta vacio!";
        }
        T_Eps.Enabled = true;
    }

    protected void BTN_EliminarEps_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (!DBEps.hayUnUsuarioConEstaEps(int.Parse(btn.CommandName)))
        {
            DBEps.eliminarEps(int.Parse(btn.CommandName));
            LB_MensajeEps.Text = "Elimino correctamente!";
            GV_Eps.DataBind();
        }
        else
        {
            LB_MensajeEps.Text = "Hay usuarios registrados con esa eps!";
        }
        T_Eps.Enabled = true;
    }

}