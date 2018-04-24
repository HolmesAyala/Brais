using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Medico_HorarioTrabajo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DBMedico medic = new DBMedico();
        //int[] dias = new int[CB_dias.Items.Count];
        //LLENAR EL ARRAY DE LOS DIAS CON 11 PARA SABER QUE EL ELEMENTO NO ESTA SELECCIONADO
        //for (int i = 0; i < CB_dias.Items.Count;i++){
         //   dias[i] = 11;}
        //SE OBTIENEN LOS DIAS SELECCIONADOS
        //for (int i = 0; i < CB_dias.Items.Count; i++)
        //{
          //  if (CB_dias.Items[i].Selected)
           // {
             //    dias[i]= int.Parse(CB_dias.Items[i].Value);
            //}
        //}
        //SE ALMACENA EN LA BD LOS DIAS DE TRABAJO ESCOGIDOS
        //for (int i = 0; i < CB_dias.Items.Count; i++)
        //{
          //  if (dias[i] != 11)
           // {
            //    medic.insertar_dias_de_trabajo(dias[i], Session["identificacion_medico"].ToString());
            //}
        //}
        //SE OBTIENEN LOS OTROS DATOS
        //EMedico emedico = new EMedico();
        //emedico.Identificacion = Session["identificacion_medico"].ToString();
        //emedico.Horas_trabajo_dia= int.Parse(DL_horas.SelectedItem.Value);
        //emedico.Hora_inicio = DateTime.Parse(DL_hora_inicial.SelectedItem.ToString());
        //medic.crear_horario(emedico);

    }
}