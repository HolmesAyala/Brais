using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EComentario
/// </summary>
public class EComentario
{
    int id, id_motivo;
    String comentario, id_remitente, id_receptor;

    public EComentario()
    { 
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

    public int Id_motivo
    {
        get
        {
            return id_motivo;
        }

        set
        {
            id_motivo = value;
        }
    }

    public string Comentario
    {
        get
        {
            return comentario;
        }

        set
        {
            comentario = value;
        }
    }

    public string Id_remitente
    {
        get
        {
            return id_remitente;
        }

        set
        {
            id_remitente = value;
        }
    }

    public string Id_receptor
    {
        get
        {
            return id_receptor;
        }

        set
        {
            id_receptor = value;
        }
    }
}