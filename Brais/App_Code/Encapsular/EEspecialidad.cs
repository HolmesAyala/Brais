using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EEspecialidad
/// </summary>
public class EEspecialidad
{

    private int id;

    private string nombre;

    public EEspecialidad()
    {

    }

    public static EEspecialidad dataTableToEEspecialidad(DataTable dtEspecialidad)
    {
        EEspecialidad eEspecialidad = new EEspecialidad();

        DataRow drEspecialidad = dtEspecialidad.Rows[0];

        eEspecialidad.id = int.Parse(drEspecialidad["id"].ToString());
        eEspecialidad.Nombre = drEspecialidad["nombre"].ToString();

        return eEspecialidad;
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
}