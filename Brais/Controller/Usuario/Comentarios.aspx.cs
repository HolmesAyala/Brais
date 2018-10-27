using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Usuario;

public partial class View_Usuario_Comentarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerCitas();
    }

    protected void obtenerCitas()
    {
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        LCita lCita = new LCita();
        GV_Comentarios.DataSource = lCita.obtenerCitasPacienteComentario(eUsuario.Identificacion);
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
        //Label test = (Label)sender;
        //String data=test.Text;
        Button btnSeleccionarCita = (Button)sender;
        btnSeleccionarCita.CommandArgument.ToString();
        Session["cita"] = btnSeleccionarCita.CommandArgument.ToString();
        EUsuario eUsuario = (EUsuario)Session["usuario"];
        LCita lCita = new LCita();
        DataTable cita = lCita.obtenerCitasPacienteComentario(eUsuario.Identificacion);
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
            eComentario.Id_cita = int.Parse(Session["cita"].ToString());
            eComentario.Session = Session.SessionID;
            LComentario lComentario = new LComentario();
            lComentario.guardarComentario(eComentario);
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
        LCita lCita = new LCita();
        DataTable cita = lCita.obtenerCita(id_cita);
        eComentario.Id_motivo = int.Parse(DDL_Motivo.SelectedItem.Value);
        eComentario.Id_receptor = cita.Rows[0]["id_medico"].ToString();
        eComentario.Id_remitente = cita.Rows[0]["id_usuario"].ToString();
        eComentario.Comentario = TB_Comentario.Text.ToString();
    }

    protected Boolean validarDatos()
    {
        LComentario lComentario = new LComentario();
        Boolean validar = false;
        try
        {
            lComentario.validarComentario(DDL_Motivo.SelectedIndex, TB_Comentario.Text.ToString().Length);
            validar = true;
        }
        catch (Exception ex)
        {
            LB_Mensaje.Text = "Tenga en cuenta:<br/>" + ex.Message.ToString();
            LB_Mensaje.Visible = true;
            validar = false;
        }
        return validar;
    }
}