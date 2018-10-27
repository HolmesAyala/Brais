using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaria.Clases.Medico
{
    public class ReporteCita
    {
        private String hora;

        private String tipoIdentificación;

        private String identificacion;

        private String nombre;

        private String apellido;

        public string Hora { get => hora; set => hora = value; }
        public string TipoIdentificación { get => tipoIdentificación; set => tipoIdentificación = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}
