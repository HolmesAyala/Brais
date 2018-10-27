using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaria.Clases.Administrador
{
    public class ReporteConsultorios
    {
        private String nombre;

        private String ubicacion;

        private String disponible;

        public string Disponible { get => disponible; set => disponible = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
