using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Rango
/// </summary>
public class Rango
{

    private string inicio;

    private string fin;

    public Rango()
    {
    }

    public string Inicio
    {
        get
        {
            return inicio;
        }

        set
        {
            inicio = value;
        }
    }

    public string Fin
    {
        get
        {
            return fin;
        }

        set
        {
            fin = value;
        }
    }
}