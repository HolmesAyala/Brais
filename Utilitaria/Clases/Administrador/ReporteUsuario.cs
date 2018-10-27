using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaria.Clases.Administrador
{
    public class ReporteUsuario
    {
        private String identificacion;

        private String tipo;

        private String nombre;

        private String apellido;

        private String afiliacion;

        private String correo;

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Afiliacion { get => afiliacion; set => afiliacion = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
