using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EUsuario
/// </summary>
public class EUsuario
{
    private string identificacion, nombre, apellido, correo, password,fecha, session;
    private int tipo_afiliacion, tipo_id, tipoUsuario, idEps;

    public string Identificacion
    {
        get
        {
            return identificacion;
        }

        set
        {
            identificacion = value;
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

    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }

    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public int Tipo_afiliacion
    {
        get
        {
            return tipo_afiliacion;
        }

        set
        {
            tipo_afiliacion = value;
        }
    }

    public int Tipo_id
    {
        get
        {
            return tipo_id;
        }

        set
        {
            tipo_id = value;
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

    public int TipoUsuario
    {
        get
        {
            return tipoUsuario;
        }

        set
        {
            tipoUsuario = value;
        }
    }

    public int IdEps
    {
        get
        {
            return idEps;
        }

        set
        {
            idEps = value;
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