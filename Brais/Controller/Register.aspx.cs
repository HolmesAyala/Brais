using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        EUsuario user = new EUsuario();
        ClientScriptManager cm = this.ClientScript;
        if (TB_pasword.Text == TB_password2.Text)
        {
            user.Apellido = TB_lastName.Text.ToString();
            user.Correo = TB_email.Text.ToString();
            user.Identificacion = TB_id.Text.ToString();
            user.Nombre = TB_name.Text.ToString();
            user.Password = TB_pasword.Text.ToString();
            user.Tipo_afiliacion = int.Parse(Tipo.SelectedValue);
            user.Tipo_id = int.Parse(DropDownList1.SelectedValue);
            user.Fecha = TB_date.Text.ToString();
            DBUsuario bd =new DBUsuario();
            bd.CrearUsuario(user);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Se Ha Creado Usuario Exitosamente');</script>");
        }
        else
        {
            //ESTA MAL LA CLAVE
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Las Contraseñas Dadas No Coinciden');</script>");
        }
        

    }


}