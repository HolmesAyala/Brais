using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EConsultorio
/// </summary>
public class EConsultorio
{
    private int id;
    private string nombre,ubicacion,session;

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

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }

    public string Ubicacion
    {
        get
        {
            return ubicacion;
        }

        set
        {
            ubicacion = value;
        }
    }

    public string Session
    {
        get
        {
            return session;
        }

        set
        {
            session = value;
        }
    }
}