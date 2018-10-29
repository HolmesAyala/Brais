using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases.Usuario
{
    public class ReporteHistorialCitas
    { 

        private String fecha;

        private String horaInicio;

        private String horaFin;

        private String pago;

        public string Fecha { get => fecha; set => fecha = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFin { get => horaFin; set => horaFin = value; }
        public string Pago { get => pago; set => pago = value; }
    }
}
