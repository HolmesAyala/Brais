using Data.Clases.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Usuario;

namespace Logica.Clases.Usuario
{
    public class LComentario
    {
        public DataTable guardarComentario(EComentario eComentario)
        {
            DAOComentario dAOComentario = new DAOComentario();
            return dAOComentario.guardarComentario(eComentario);
        }

        public Boolean validarComentario(int motivo, int comentario)
        {
            String mensaje = "";
            if (motivo == 0)
            {
                mensaje += "- No ha seleccionado un motivo de PQR<br/>";
            }
            if (comentario == 0)
            {
                mensaje += "- No puede dejar el campo vacio.<br/>";
            }
            if (!mensaje.Equals(""))
            {
                throw new Exception(mensaje);
            }
        }
    }
}
