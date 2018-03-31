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

        //DDL_Tipo_Documento.SelectedIndex = 0;
        //eUsuario.Tipo_id-1
        TB_Numero_Documento.Text = eUsuario.Identificacion;
        TB_Numero_Documento.Enabled = false;
        TB_Nombre.Text = usuario.Rows[0]["nombre"].ToString();
        TB_Apellido.Text = eUsuario.Apellido;
        TB_FechaNacimiento.TextMode = TextBoxMode.Date;
        TB_FechaNacimiento.Text = string.Join("-", eUsuario.Fecha.Substring(0, 10).Split('/').Reverse());
        //DDL_TipoAfiliacion.SelectedIndex =0;
        // eUsuario.Tipo_afiliacion-1
        TB_Correo.Text = eUsuario.Correo;
        TB_Clave.Attributes.Add("value", eUsuario.Password);
        TB_RepetirClave.Attributes.Add("value", eUsuario.Password);
        BTN_Accion.Text = "Actualizar";
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;
        if (validarDatos())
        {
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
    }

    protected EUsuario recolectarDatos()
    {
        EUsuario eUsuario = new EUsuario();
        eUsuario.Tipo_id = int.Parse(DDL_Tipo_Documento.SelectedItem.Value);
        eUsuario.Identificacion = TB_Numero_Documento.Text;
        eUsuario.Nombre = TB_Nombre.Text;
        eUsuario.Apellido = TB_Apellido.Text;
        eUsuario.Fecha = TB_FechaNacimiento.Text;
        eUsuario.Tipo_afiliacion = int.Parse(DDL_TipoAfiliacion.SelectedItem.Value);
        eUsuario.Correo = TB_Correo.Text;
        eUsuario.Password = TB_Clave.Text;
        return eUsuario;
    }

    protected Boolean validarDatos()
    {
        string mensaje = "";
        if (DDL_Tipo_Documento.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado un tipo de documento<br/>";
        }

        if (TB_Numero_Documento.Text.Trim().Equals(""))
        {
            mensaje += "- El campo Numero de documento esta vacio<br/>";
        }
        else
        {
            DBUsuario dBUsuario = new DBUsuario();
            if (dBUsuario.obtenerUsuario(TB_Numero_Documento.Text.Trim()).Rows.Count > 0 && BTN_Accion.Text.Equals("Agregar"))
            {
                mensaje += "- YA EXISTE UN USUARIO CON ESA IDENTIFICACION<br/>";
            }
            try
            {
                int.Parse(TB_Numero_Documento.Text.Trim());
            }
            catch (Exception)
            {
                mensaje += "- El numero de documento solo debe incluir numeros<br/>";
            }
        }

        if (TB_Nombre.Text.Trim().Equals(""))
        {
            mensaje += "- El campo nombre esta vacio<br/>";
        }
        if (TB_Apellido.Text.Trim().Equals(""))
        {
            mensaje += "- El campo apellido esta vacio<br/>";
        }

        if (TB_FechaNacimiento.Text.Equals(""))
        {
            mensaje += "- No ha seleccionado fecha de nacimiento<br/>";
        }
        else if (Convert.ToDateTime(TB_FechaNacimiento.Text) > DateTime.Now)
        {
            mensaje += "- Su fecha de nacimiento debe <br/>  ser menor a la fecha actual<br/>";
        }

        if (DDL_TipoAfiliacion.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado el tipo de afiliacion<br/>";
        }

        if (TB_Correo.Text.Trim().Equals(""))
        {
            mensaje += "- El campo correo esta vacio<br/>";
        }

        if (TB_Clave.Text.Equals("") || TB_RepetirClave.Text.Equals(""))
        {
            mensaje += "- Los campos de contraseña estan vacios<br/>";
        }
        else if (!TB_Clave.Text.Equals(TB_RepetirClave.Text))
        {
            mensaje += "- Las contraseñas no coinciden<br/>";
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