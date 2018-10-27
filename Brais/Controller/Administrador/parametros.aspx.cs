using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica.Clases.Administrador;
using Utilitaria.Clases.Administrador;

public partial class View_Administrador_parametros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarParametroActual();
    }

    public void cargarParametroActual()
    {
        try
        {
            LAdministrador lAdministrador = new LAdministrador();
            String value = lAdministrador.param_actual(IsPostBack);
            DL_tiempo.SelectedValue = value;
        }
        catch(Exception ex)
        {
        }
    }

    private void llenarGridView()
    {
        LAdministrador lAdministrador = new LAdministrador(); 
        GV_consultorios.DataSource = lAdministrador.obtenerConsultorios();
        GV_consultorios.DataBind();
    }

    public EConsultorio encapsularDatos()
    {
        EConsultorio eConsultorio = new EConsultorio();
        eConsultorio.Nombre = TB_Consultorio.Text;
        eConsultorio.Ubicacion = TB_Ubicacion.Text;
        eConsultorio.Session = Session.SessionID;
        return eConsultorio;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            LAdministrador lAdministrador = new LAdministrador();
            EConsultorio eConsultorio = encapsularDatos();
            lAdministrador.insertarConsultorio(eConsultorio);
        }
        catch(Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Nombre", "<script> alert('No ha ingresado datos para el consultorio'); </script>");
        }
        Response.Redirect("~/View/Administrador/parametros.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String id;
        id = btn.CommandArgument.ToString();
        Session["id"] = id;
        Response.Redirect("~/View/Administrador/editar_consultorio.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            String id = btn.CommandArgument.ToString();
            DBConsultorio dBConsultorio = new DBConsultorio();
            //VALIDAR LO DEL COSULTORIO OCUPADO
            LConsultorio lConsultorio = new LConsultorio();
            lConsultorio.eliminar_consultorio(int.Parse(id));
            GV_consultorios.DataBind();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script> alert('No ha ingresado datos para el consultorio'); </script>");
        }
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int fk_parametro =int.Parse(DL_tiempo.SelectedItem.Value);
        LAdministrador lAdministrador = new LAdministrador();
        String sesion = Session.SessionID;
        lAdministrador.actualizar_param(fk_parametro, sesion);
        ClientScriptManager cm = this.ClientScript;
        String dato = "<script type='text/javascript'>alert('A Partir de este momento las citas van a durar " + DL_tiempo.SelectedItem + " minutos')</script>;";
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
        String especialidad = TB_AgregarEspecialidad.Text.Trim();
        try
        {
            LEspecialidad lEspecialidad = new LEspecialidad();
            lEspecialidad.agregarEspecialidad(especialidad, Session.SessionID);
            TB_AgregarEspecialidad.Text = "";
            GV_Especialidad.DataBind();
            LB_MensajeEspecialidad.Text = "Agrego correctamente!";
        }
        catch (Exception ex)
        {
            LB_MensajeEspecialidad.Text = "Esta vacio!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_AgregarEps_Click(object sender, EventArgs e)
    {
        try
        {
            String eps = TB_AgregarEps.Text.Trim();
            LEps lEps = new LEps();
            lEps.agregarEps(TB_AgregarEps.Text.Trim(), Session.SessionID);
            TB_AgregarEps.Text = "";
            GV_Eps.DataBind();
            LB_MensajeEps.Text = "Agrego correctamente!";
        }
        catch (Exception ex)
        {
            LB_MensajeEps.Text = "Esta vacio!";
        }
        T_Eps.Enabled = true;
    }

    protected void BTN_ActualizarEspecialidad_Click(object sender, EventArgs e)
    {
        try
        {
            Button id = (Button)sender;
            TextBox tb = (TextBox)id.Parent.FindControl("TB_Especialidad");
            String nombre = tb.Text.Trim();
            LEspecialidad lEspecialidad = new LEspecialidad();
            lEspecialidad.actualizarEspecialidad(int.Parse(id.CommandName), tb.Text, Session.SessionID);
            LB_MensajeEspecialidad.Text = "Actualizo correctamente!";
            GV_Especialidad.DataBind();
        }
        catch (Exception ex)
        {
            LB_MensajeEspecialidad.Text = "El nombre que va a actualizar esta vacio!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_EliminarEspecialidad_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        try
        {
            LEspecialidad lEspecialidad = new LEspecialidad();
            lEspecialidad.eliminarEspecialidad(int.Parse(btn.CommandName), Session.SessionID);
            LB_MensajeEspecialidad.Text = "Elimino correctamente!";
            GV_Especialidad.DataBind();
        }
        catch (Exception ex)
        {
            LB_MensajeEspecialidad.Text = "Hay medicos registrados con esa especialidad!";
        }
        T_Especialidad.Enabled = true;
    }

    protected void BTN_ActualizarEps_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            TextBox tb = (TextBox)btn.Parent.FindControl("TB_Eps");
            String nombre = tb.Text.Trim();
            LEps lEps = new LEps();
            lEps.actualizarEps(int.Parse(btn.CommandName), tb.Text, Session.SessionID);
            LB_MensajeEps.Text = "Actualizo correctamente!";
            GV_Eps.DataBind();
        }
        catch (Exception ex)
        {
            LB_MensajeEps.Text = "El nombre que va a actualizar esta vacio!";

        }
        T_Eps.Enabled = true;
    }

    protected void BTN_EliminarEps_Click(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandName);
            LEps lEps = new LEps();
            lEps.eliminarEps(id);
            LB_MensajeEps.Text = "Elimino correctamente!";
            GV_Eps.DataBind();
        }
        catch (Exception ex)
        {
            LB_MensajeEps.Text = "Hay usuarios registrados con esa eps!";
        }
        T_Eps.Enabled = true;
    }

    protected void GV_consultorios_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
        
    }

    protected void GV_Eps_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if ( e.Row.RowIndex == 0 )
        {
            e.Row.Visible = false;
        }
        
    }
    
}