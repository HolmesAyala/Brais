using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EMedico
/// </summary>
public class EMedico
{
    private string identificacion, nombre, apellido, correo, password, fechaNacimiento,horario;
    private int tipoEspecialidad, consultorio, tipoUsuario, tipoIdentificacion;
    private EEspecialidad eEspecialidad;

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

    public string FechaNacimiento
    {
        get
        {
            return fechaNacimiento;
        }

        set
        {
            fechaNacimiento = value;
        }
    }

    public int TipoEspecialidad
    {
        get
        {
            return tipoEspecialidad;
        }

        set
        {
            tipoEspecialidad = value;
        }
    }

    public int Consultorio
    {
        get
        {
            return consultorio;
        }

        set
        {
            consultorio = value;
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

    public int TipoIdentificacion
    {
        get
        {
            return tipoIdentificacion;
        }

        set
        {
            tipoIdentificacion = value;
        }
    }

    public string Horario
    {
        get
        {
            return horario;
        }

        set
        {
            horario = value;
        }
    }

    public EEspecialidad EEspecialidad
    {
        get
        {
            return eEspecialidad;
        }

        set
        {
            eEspecialidad = value;
        }
    }
}