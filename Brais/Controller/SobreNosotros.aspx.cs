using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_SobreNosotros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IF DE USUARIO NORMAL
        if (Session["usuario"] != null)
        {
            Response.Redirect("~/View/Usuario/AsignarCita.aspx");
        }
        //OTROS IF 
    }
}