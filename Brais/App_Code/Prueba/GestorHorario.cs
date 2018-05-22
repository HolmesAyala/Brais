using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Horario
/// </summary>
public class GestorHorario
{

    public GestorHorario()
    {

    }

    public static Boolean agregarDia(List<Dia> dias, Dia dia)
    {
        if (!validarCruce(dias, dia))
        {
            return false;
        }
        Boolean elDiaEstaEnLaLista = false;
        foreach (Dia d in dias)
        {
            if (dia.DiaSemana == d.DiaSemana)
            {
                d.Rangos.AddRange(dia.Rangos);
                elDiaEstaEnLaLista = true;
                break;
            }
        }
        if (!elDiaEstaEnLaLista)
        {
            dias.Add(dia);
        }
        return true;
    }

    public static Boolean validarCruce(List<Dia> dias, Dia dia)
    {
        Rango rango = dia.Rangos.First();
        foreach(Dia d in dias)
        {
            if (dia.DiaSemana == d.DiaSemana)
            {
                foreach (Rango r in d.Rangos)
                {
                    if ( (DateTime.Parse(r.Inicio) == DateTime.Parse(rango.Inicio) && DateTime.Parse(r.Fin) == DateTime.Parse(rango.Fin)) ||
                         (DateTime.Parse(rango.Inicio) < DateTime.Parse(r.Inicio) && DateTime.Parse(r.Inicio) < DateTime.Parse(rango.Fin)) ||
                         (DateTime.Parse(rango.Inicio) < DateTime.Parse(r.Fin) && DateTime.Parse(r.Fin) < DateTime.Parse(rango.Fin))
                        )
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public static void eliminarRango(int dia, Rango rango, List<Dia> dias)
    {
        foreach (Dia d in dias)
        {
            if (d.DiaSemana == dia)
            {
                foreach (Rango r in d.Rangos)
                {
                    if (r.Inicio == rango.Inicio && r.Fin == rango.Fin)
                    {
                        d.Rangos.Remove(r);
                        break;
                    }
                }
                if (d.Rangos.Count == 0) { dias.Remove(d); break; }
            }
        }
    }

}