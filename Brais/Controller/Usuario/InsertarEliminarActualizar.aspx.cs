using Data.Clases;
using Logica.Clases;
using Logica.Clases.Administrador;
using Logica.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Usuario;

public partial class View_Usuario_InsertarEliminarActualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        Response.Cache.SetNoStore();
        if (Session["usuario"] == null)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        if (!IsPostBack)
        {
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
        }
    }

    protected void adecuarParaInsertar()
    {
        cargarEps();
        BTN_Accion.Text = "Agregar";
        DDL_Eps.Enabled = false;
    }

    protected void cargarEps()
    {
        LEps lEps = new LEps();
       
        foreach (DataRow fila in lEps.obtenerEps().Rows)
        {
            ListItem listItem = new ListItem(fila["nombre"].ToString(), fila["id"].ToString());
             DDL_Eps.Items.Add(listItem);
        }
    }

    protected void adecuarParaActualizar()
    {
        string identificacion = Session["identificacion"].ToString();

        LUsuario lUsuario = new LUsuario();
        LFuncion  lFuncion = new LFuncion();

        DataTable dtUsuario = lUsuario.obtenerUsuario(identificacion);

        EUsuario eUsuario = lFuncion.dataTableToEUsuario(dtUsuario);

        DDL_Tipo_Documento.SelectedIndex = eUsuario.Tipo_id;
        TB_Numero_Documento.Text = eUsuario.Identificacion;
        TB_Nombre.Text = eUsuario.Nombre;
        TB_Apellido.Text = eUsuario.Apellido;
        TB_FechaNacimiento.TextMode = TextBoxMode.Date;
        TB_FechaNacimiento.Text = DateTime.Parse(eUsuario.Fecha).ToString("yyyy-MM-dd");
        DDL_TipoAfiliacion.SelectedIndex = eUsuario.Tipo_afiliacion;
        TB_Correo.Text = eUsuario.Correo;
        TB_Clave.Attributes.Add("value", eUsuario.Password);
        TB_RepetirClave.Attributes.Add("value", eUsuario.Password);
        BTN_Accion.Text = "Actualizar";

        cargarEps();

        foreach (ListItem listItem in DDL_Eps.Items)
        {
            listItem.Selected = int.Parse(listItem.Value) == eUsuario.IdEps;
        }

        if (eUsuario.Tipo_afiliacion == 2)
        {
            DDL_Eps.Enabled = false;
        }

        if( ((EUsuario)Session["usuario"]).TipoUsuario == 3 )
        {
            DDL_Tipo_Documento.Enabled = false;
            TB_Numero_Documento.Enabled = false;
            TB_Nombre.Enabled = false;
            TB_Apellido.Enabled = false;
            TB_FechaNacimiento.Enabled = false;
            DDL_TipoAfiliacion.Enabled = false;
            DDL_Eps.Enabled = false;
        }
    }

    protected void BTN_Accion_Click(object sender, EventArgs e)
    {
        Button btnAccion = (Button)sender;
        if (validarDatos())
        {
            EUsuario eUsuario = recolectarDatos();

            LUsuario lUsuario = new LUsuario();
            lUsuario.insertarActualizar(btnAccion.Text, eUsuario);

            Session["Accion"] = null;
            Session["identificacion"] = null;
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
        eUsuario.Session = Session.SessionID;
        return eUsuario;
    }

    protected Boolean validarDatos()
    {
        EUsuario eUsuario = recolectarDatos();
        LUsuario lUsuario = new LUsuario();
        Boolean validar = false;
        try
        {
            validar = lUsuario.validarDatos(BTN_Accion.Text, Session["identificacion"], eUsuario, DDL_TipoAfiliacion.SelectedItem.Text, TB_RepetirClave.ToString());
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

    protected void imprimirConsola(String mensaje)
    {
        
    }

}