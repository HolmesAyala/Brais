using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Medico;
using Logica.Clases.Medico;
using Logica.Clases.Administrador;
using Logica.Clases.Usuario;
using Logica.Clases;

public partial class View_Medico_HistorialPaciente : System.Web.UI.Page
{

    EMedico eMedico;

    EUsuario eUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LMedico lMedico = new LMedico();
            lMedico.validarMedico(eUsuario = (EUsuario)Session["paciente"], eMedico = (EMedico)Session["medico"]);
            mostrarInformacionBasica();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/View/Login.aspx");
        }

    }

    protected void mostrarInformacionBasica()
    {
        eMedico = (EMedico)Session["medico"];
        eUsuario = (EUsuario)Session["paciente"];

        TB_Fecha.Text = DateTime.Now.ToShortDateString();
        TB_NombreMedico.Text = eMedico.Nombre + " " + eMedico.Apellido;
        TB_NombrePaciente.Text = eUsuario.Nombre + " " + eUsuario.Apellido;

        LEspecialidad lEspecialidad = new LEspecialidad();
        TB_NombreServicio.Text = lEspecialidad.obtenerEspecialidad(eMedico.TipoEspecialidad).Rows[0]["nombre"].ToString();

        cargarDatosHistorial(eUsuario.Identificacion);

        if (GV_Historial.Rows.Count <= 0)
        {
            LB_Mensaje.Text = "El paciente no tiene historial medico.";
        }

    }


    protected void BTN_Agregar_Click(object sender, EventArgs e)
    {
        EHistorial eHistorial = new EHistorial();

        eHistorial.Fecha = TB_Fecha.Text.Trim();
        eHistorial.IdMedico = eMedico.Identificacion;
        eHistorial.IdUsuario = eUsuario.Identificacion;
        eHistorial.Servicio = TB_NombreServicio.Text.Trim();
        eHistorial.MotivoConsulta = TB_MotivoConsulta.Text.Trim();
        eHistorial.Observacion = TB_Observacion.Text.Trim();
        eHistorial.Session = Session.SessionID;

        LHistorial lHistorial = new LHistorial();
        lHistorial.agregarHistorial(eHistorial);

        Session["medico"] = null;
        Session["paciente"] = null;

        try
        {
            LFuncion lFuncion = new LFuncion();
            lFuncion.validarPaginaAnterior(Session["paginaAnterior"]);
        }
        catch (Exception ex)
        {
            Response.Redirect(Session["paginaAnterior"].ToString());
        }


    }

    protected void cargarDatosHistorial(string idUsuario)
    {
        LHistorial lHistorial = new LHistorial();
        GV_Historial.DataSource = lHistorial.obtenerHistorial(idUsuario);
        GV_Historial.DataBind();
    }

    protected void GV_Historial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Historial.PageIndex = e.NewPageIndex;
        cargarDatosHistorial(eUsuario.Identificacion);
    }

}