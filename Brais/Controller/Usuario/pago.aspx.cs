﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Usuario_pago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //SE ACTIVA EL PAGO
        Button btn = (Button)sender;
        DBCitasUsr cite = new DBCitasUsr();
        EUsuario usr = (EUsuario)Session["usuario"];
        cite.activar_pago(usr.Identificacion, int.Parse(Session["id_payment"].ToString()));
        ClientScriptManager cm = this.ClientScript;
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ha Realizado el respectivo pago')</script>;");
        Response.Redirect("citas_no_pag.aspx");
    }
}