using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_InsertarEliminarActualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["Accion"] != null)
        {
            if (Session["Accion"].ToString().Equals("Insertar"))
            {
                adecuarParaInsertar();
            }
            else if (Session["Accion"].ToString().Equals("Actualizar"))
            {
                adecuarParaActualizar();
            }
            else if (Session["Accion"].ToString().Equals("Eliminar"))
            {
            }
        }
        else
        {
            Response.Redirect("~/View/PaginaPrincipal.aspx");
        }
    }
    

    protected void adecuarParaInsertar()
    {
        BTN_Accion.Text = "Agregar";
    }

    protected void adecuarParaActualizar()
    {
        string identificacion = Session["identificacion"].ToString();

        DBUsuario dBUsuario = new DBUsuario();

        DataTable usuario = dBUsuario.obtenerUsuario(identificacion);

        EUsuario eUsuario = new EUsuario();

        eUsuario.Tipo_id = int.Parse(usuario.Rows[0]["id_tipo_identificacion"].ToString());
        eUsuario.Identificacion = usuario.Rows[0]["identificacion"].ToString();
        eUsuario.Nombre = usuario.Rows[0]["nombre"].ToString();
        eUsuario.Apellido = usuario.Rows[0]["apellido"].ToString();
        eUsuario.Fecha = usuario.Rows[0]["fecha_nacimiento"].ToString();
        eUsuario.Tipo_afiliacion = int.Parse(usuario.Rows[0]["id_tipo_afiliacion"].ToString());
        eUsuario.Correo = usuario.Rows[0]["correo"].ToString();
        eUsuario.Password = usuario.Rows[0]["contrasena"].ToString();

        DDL_Tipo_Documento.SelectedIndex = eUsuario.Tipo_id;
        TB_Numero_Documento.Text = eUsuario.Identificacion;
        TB_Numero_Documento.Enabled = false;
        TB_Nombre.Text = usuario.Rows[0]["nombre"].ToString();
        TB_Apellido.Text = eUsuario.Apellido;
        TB_FechaNacimiento.TextMode = TextBoxMode.Date;
        TB_FechaNacimiento.Text = string.Join("-", eUsuario.Fecha.Substring(0, 10).Split('/').Reverse());
        DDL_TipoAfiliacion.SelectedIndex = eUsuario.Tipo_afiliacion;
        TB_Correo.Text = eUsuario.Correo;
        TB_Clave.Attributes.Add("value", eUsuario.Password);
        TB_RepetirClave.Attributes.Add("value", eUsuario.Password);
        BTN_Accion.Text = "Actualizar";
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;
        if (btnAccion.Text.Equals("Agregar"))
        {
            EUsuario eUsuario = recolectarDatos();
            DBUsuario dBUsuario = new DBUsuario();
            dBUsuario.CrearUsuario(eUsuario);
        }
        else if (btnAccion.Text.Equals("Actualizar"))
        {
            EUsuario eUsuario = recolectarDatos();
            DBUsuario dBUsuario = new DBUsuario();
            dBUsuario.actualizarUsuario(eUsuario);
        }
        else if (btnAccion.Text.Equals("Eliminar"))
        {
        }
        Session["Accion"] = null;
        Session["identificacion"] = null;
        Response.Redirect(Session["PaginaAnterior"].ToString());
    }

    protected EUsuario recolectarDatos()
    {
        EUsuario eUsuario = new EUsuario();
        eUsuario.Tipo_id = int.Parse(DDL_Tipo_Documento.SelectedValue);
        eUsuario.Identificacion = TB_Numero_Documento.Text;
        eUsuario.Nombre = TB_Nombre.Text;
        eUsuario.Apellido = TB_Apellido.Text;
        eUsuario.Fecha = TB_FechaNacimiento.Text;
        eUsuario.Tipo_afiliacion = int.Parse(DDL_TipoAfiliacion.SelectedItem.Value);
        eUsuario.Correo = TB_Correo.Text;
        eUsuario.Password = TB_Clave.Text;
        return eUsuario;
    }
}