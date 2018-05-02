using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ECita
/// </summary>
public class ECita
{

    private int id;

    private EMedico eMedico;

    private EUsuario eUsuario;

    private string horaInicio;

    private string horaFin;

    private string dia;

    public ECita()
    {

    }

    public static ECita dataTableToECita(DataTable dtCita)
    {
        DataRow drCita = dtCita.Rows[0];
        DBMedico dBMedico = new DBMedico();
        DBUsuario dBUsuario = new DBUsuario();

        ECita eCita = new ECita();

        eCita.Id = int.Parse(drCita["id"].ToString());
        eCita.EMedico = Funcion.dataTableToEMedico(dBMedico.obtenerMedico(drCita["id_medico"].ToString()));
        eCita.EUsuario = Funcion.dataTableToEUsuario(dBUsuario.obtenerUsuario(drCita["id_usuario"].ToString()));
        eCita.HoraInicio = drCita["hora_inicio"].ToString();
        eCita.HoraFin = drCita["hora_fin"].ToString();
        eCita.Dia = drCita["dia"].ToString();

        return eCita;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string HoraInicio
    {
        get
        {
            return horaInicio;
        }

        set
        {
            horaInicio = value;
        }
    }

    public string HoraFin
    {
        get
        {
            return horaFin;
        }

        set
        {
            horaFin = value;
        }
    }

    public string Dia
    {
        get
        {
            return dia;
        }

        set
        {
            dia = value;
        }
    }

    public EMedico EMedico
    {
        get
        {
            return eMedico;
        }

        set
        {
            eMedico = value;
        }
    }

    public EUsuario EUsuario
    {
        get
        {
            return eUsuario;
        }

        set
        {
            eUsuario = value;
        }
    }
}