﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_editar_consultorio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        llenarCampos(getConsultorio());

    }

    private DataTable getConsultorio()
    {
        int id = int.Parse(Session["id"].ToString());
        DBAdministrador admin = new DBAdministrador();
        DataTable consultorio;
        consultorio = admin.obtenerConsultorio(id);
        return consultorio;
    }

    private void llenarCampos(DataTable consul)
    {
        TB_nombre.Text = consul.Rows[0]["nombre"].ToString();
        TB_ubicacion.Text = consul.Rows[0]["ubicacion"].ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}