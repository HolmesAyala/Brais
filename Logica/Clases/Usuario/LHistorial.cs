using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Usuario;
using Data.Clases.Usuario;

namespace Logica.Clases.Usuario
{
    public class LHistorial
    {
        public DataTable agregarHistorial(EHistorial eHistorial)
        {
            DAOHistorial dAOHistorial = new DAOHistorial();
            DataTable historial = dAOHistorial.agregarHistorial(eHistorial);
            return historial;
        }

        public DataTable obtenerHistorial(String idUsuario)
        {
            DAOHistorial dAOHistorial = new DAOHistorial();
            DataTable historial =  dAOHistorial.obtenerHistorial(idUsuario);
            return historial;
        }
    }
}
