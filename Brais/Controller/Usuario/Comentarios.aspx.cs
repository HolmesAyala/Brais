using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_Comentarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitas();
    }

    protected void obtenerCitas()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DBCita dBCita = new DBCita();
        GV_Comentarios.DataSource = dBCita.obtenerCitasPacienteComentario(eUsuario.Identificacion);
        GV_Comentarios.DataBind();
    }

    protected void GV_Comentarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Comentarios.PageIndex = e.NewPageIndex;
        obtenerCitas();
    }

    protected void GV_Comentarios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BTN_Seleccionar_Click(object sender, EventArgs e)
    {
        Button btnSeleccionarCita = (Button)sender;
        Session["cita"] = btnSeleccionarCita.CommandArgument.ToString();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        DBCita dBCita = new DBCita();
        DataTable cita = dBCita.obtenerCitasPacienteComentario(eUsuario.Identificacion);
        L_Especialidad.Text = cita.Rows[0]["especialidad"].ToString();
        L_medico.Text = cita.Rows[0]["nombre_medico"].ToString();
        T_Comentario.Visible = true;
    }

    protected void BTN_Confirmar_Click(object sender, EventArgs e)
    {
        if (validarDatos())
        {
            EComentario eComentario = new EComentario();
            recolectarDatos(eComentario);
            DBComentario.guardarComentario(eComentario);
            string script = @"<script type='text/javascript'>alert('El comentario se agrego correctamente');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            TB_Comentario.Visible = false;
            Response.Redirect("~/View/Usuario/Comentarios.aspx");
        }
        
    }
    
    protected void recolectarDatos(EComentario eComentario)
    {
        String _id_cita = Session["cita"].ToString();
        int id_cita = Convert.ToInt32(_id_cita);
        DataTable cita = DBCita.obtenerCita(id_cita);
        eComentario.Id_motivo = int.Parse(DDL_Motivo.SelectedItem.Value);
        eComentario.Id_receptor = cita.Rows[0]["id_medico"].ToString();
        eComentario.Id_remitente = cita.Rows[0]["id_usuario"].ToString();
        eComentario.Comentario = TB_Comentario.Text.ToString();
    }

    protected Boolean validarDatos()
    {
        String mensaje = "";
        if (DDL_Motivo.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado un motivo de PQR<br/>";
        }
        if (TB_Comentario.Text.ToString().Length == 0)
        {
            mensaje += "- No puede dejar el campo vacio.<br/>";
        }
        if (!mensaje.Equals(""))
        {
            LB_Mensaje.Text = "Tenga en cuenta:<br/>" + mensaje;
            LB_Mensaje.Visible = true;
            return false;
        }
        return true;
    }
}