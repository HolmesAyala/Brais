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
        MaintainScrollPositionOnPostBack = true;
        Response.Cache.SetNoStore();
        if (Session["usuario"] == null && Session["Crear_cuenta"] == null)
        {
            Response.Redirect("~/View/Login.aspx");
        }

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
            Session["Accion"] = null;
            Session["identificacion"] = null;
        }
        if (Session["Crear_cuenta"].ToString().Equals("Crear cuenta"))
        {
            adecuarParaInsertar();
        }
    }

    protected void adecuarParaInsertar()
    {
        BTN_Accion.Text = "Agregar";
        DDL_Eps.Enabled = false;
    }

    protected void adecuarParaActualizar()
    {
        if (((EUsuario)Session["usuario"]).TipoUsuario == 1)
        {
            string identificacion = Session["identificacion"].ToString();

            DBUsuario dBUsuario = new DBUsuario();

            DataTable dtUsuario = dBUsuario.obtenerUsuario(identificacion);

            EUsuario eUsuario = Funcion.dataTableToEUsuario(dtUsuario);

            DDL_Tipo_Documento.SelectedIndex = eUsuario.Tipo_id;
            TB_Numero_Documento.Text = eUsuario.Identificacion;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Text = eUsuario.Nombre;
            TB_Apellido.Text = eUsuario.Apellido;
            TB_FechaNacimiento.TextMode = TextBoxMode.Date;
            TB_FechaNacimiento.Text = DateTime.Parse(eUsuario.Fecha).ToString("yyyy-MM-dd");
            DDL_TipoAfiliacion.SelectedIndex = eUsuario.Tipo_afiliacion;
            DDL_Eps.SelectedIndex = eUsuario.IdEps;
            TB_Correo.Text = eUsuario.Correo;
            TB_Clave.Attributes.Add("value", eUsuario.Password);
            TB_RepetirClave.Attributes.Add("value", eUsuario.Password);
            BTN_Accion.Text = "Actualizar";

            if (eUsuario.Tipo_afiliacion == 2)
            {
                DDL_Eps.Enabled = false;
            }

        }else if(((EUsuario)Session["usuario"]).TipoUsuario == 3)
        {
            string identificacion = Session["identificacion"].ToString();

            DBUsuario dBUsuario = new DBUsuario();

            DataTable dtUsuario = dBUsuario.obtenerUsuario(identificacion);

            EUsuario eUsuario = Funcion.dataTableToEUsuario(dtUsuario);

            DDL_Tipo_Documento.SelectedIndex = eUsuario.Tipo_id;
            DDL_Tipo_Documento.Enabled = false;
            TB_Numero_Documento.Text = eUsuario.Identificacion;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Text = eUsuario.Nombre;
            TB_Nombre.Enabled = false;
            TB_Apellido.Text = eUsuario.Apellido;
            TB_Apellido.Enabled = false;
            TB_FechaNacimiento.TextMode = TextBoxMode.Date;
            TB_FechaNacimiento.Text = DateTime.Parse(eUsuario.Fecha).ToString("yyyy-MM-dd");
            TB_FechaNacimiento.Enabled = false;
            DDL_TipoAfiliacion.SelectedIndex = eUsuario.Tipo_afiliacion;
            DDL_TipoAfiliacion.Enabled = false;
            DDL_Eps.SelectedIndex = eUsuario.IdEps;
            DDL_Eps.Enabled = false;
            TB_Correo.Text = eUsuario.Correo;
            TB_Clave.Attributes.Add("value", eUsuario.Password);
            TB_RepetirClave.Attributes.Add("value", eUsuario.Password);
            BTN_Accion.Text = "Actualizar";

            if (eUsuario.Tipo_afiliacion == 2)
            {
                DDL_Eps.Enabled = false;
            }
        }
        

    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;
        if (validarDatos())
        {
            EUsuario eUsuario = recolectarDatos();
            DBUsuario dBUsuario = new DBUsuario();

            if (btnAccion.Text.Equals("Agregar"))
            {
                dBUsuario.CrearUsuario(eUsuario);
            }
            else if (btnAccion.Text.Equals("Actualizar"))
            {
                dBUsuario.actualizarUsuario(eUsuario);
            }
            else if (btnAccion.Text.Equals("Eliminar"))
            {

            }
            Session["Crear_cuenta"] = null;
            Response.Redirect(Session["PaginaAnterior"].ToString());
        }
    }

    protected void DDL_TipoAfiliacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DDLTipoAfiliacion = (DropDownList)sender;
        if (DDLTipoAfiliacion.SelectedItem.Text == "E.P.S.")
        {
            DDL_Eps.Enabled = true;
        }
        else
        {
            DDL_Eps.Enabled = false;
            DDL_Eps.SelectedIndex = 0;
        }
        
    }

    protected EUsuario recolectarDatos()
    {
        EUsuario eUsuario = new EUsuario();
        eUsuario.Tipo_id = int.Parse(DDL_Tipo_Documento.SelectedItem.Value);
        eUsuario.Identificacion = TB_Numero_Documento.Text.Trim();
        eUsuario.Nombre = TB_Nombre.Text.Trim();
        eUsuario.Apellido = TB_Apellido.Text.Trim();
        eUsuario.Fecha = TB_FechaNacimiento.Text;
        eUsuario.Tipo_afiliacion = int.Parse(DDL_TipoAfiliacion.SelectedItem.Value);
        eUsuario.IdEps = int.Parse(DDL_Eps.SelectedItem.Value);
        eUsuario.Correo = TB_Correo.Text.Trim();
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
        else if (DDL_TipoAfiliacion.SelectedItem.Text.Equals("E.P.S.") && DDL_Eps.SelectedIndex == 0)
        {
            mensaje += "- No ha seleccionado su E.P.S.<br/>";
        }

        if (TB_Correo.Text.Trim().Equals(""))
        {
            mensaje += "- El campo correo esta vacio<br/>";
        }
        else if (!DBUsuario.validarExistenciaCorreo(TB_Correo.Text.Trim()) && BTN_Accion.Text.Equals("Agregar"))
        {
            mensaje += "- El correo ya se encuentra registrado<br/>";
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

    protected void imprimirConsola(String mensaje)
    {
        Response.Write("<script>console.log('" + mensaje + "');</script>");
    }

}