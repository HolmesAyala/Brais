using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EHistorial
/// </summary>
public class EHistorial
{

    private string idMedico;

    private string idUsuario;

    private string motivoConsulta;

    private string observacion;

    private string fecha;

    private string servicio;

    public EHistorial()
    {

    }

    public string MotivoConsulta
    {
        get
        {
            return motivoConsulta;
        }

        set
        {
            motivoConsulta = value;
        }
    }

    public string Observacion
    {
        get
        {
            return observacion;
        }

        set
        {
            observacion = value;
        }
    }

    public string Fecha
    {
        get
        {
            return fecha;
        }

        set
        {
            fecha = value;
        }
    }

    public string Servicio
    {
        get
        {
            return servicio;
        }

        set
        {
            servicio = value;
        }
    }

    public string IdMedico
    {
        get
        {
            return idMedico;
        }

        set
        {
            idMedico = value;
        }
    }

    public string IdUsuario
    {
        get
        {
            return idUsuario;
        }

        set
        {
            idUsuario = value;
        }
    }
}