using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Descripción breve de Dia
/// </summary>
public class Dia
{
    private int diaSemana;

    private List<Rango> rangos = new List<Rango>();

    public Dia()
    {
    }

    public List<Rango> Rangos
    {
        get
        {
            return rangos;
        }

        set
        {
            rangos = value;
        }
    }

    public int DiaSemana
    {
        get
        {
            return diaSemana;
        }

        set
        {
            diaSemana = value;
        }
    }
}