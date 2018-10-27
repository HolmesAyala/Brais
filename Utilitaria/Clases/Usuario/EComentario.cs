using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EComentario
/// </summary>
/// 

namespace Utilitaria.Clases.Usuario
{

    public class EComentario
    {
        int id, id_motivo, id_cita;
        String comentario, id_remitente, id_receptor, session;

        public EComentario()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Id_motivo { get => id_motivo; set => id_motivo = value; }
        public int Id_cita { get => id_cita; set => id_cita = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Id_remitente { get => id_remitente; set => id_remitente = value; }
        public string Id_receptor { get => id_receptor; set => id_receptor = value; }
        public string Session { get => session; set => session = value; }
    }
}