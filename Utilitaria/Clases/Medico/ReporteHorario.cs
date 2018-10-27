using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaria.Clases.Medico
{
    public class ReporteHorario
    {
        private String lunes;

        private String martes;

        private String miercoles;

        private String jueves;

        private String viernes;

        private String sabado;

        private String domingo;

        public String Lunes { get => lunes; set => lunes = value; }
        public String Martes { get => martes; set => martes = value; }
        public String Miercoles { get => miercoles; set => miercoles = value; }
        public String Jueves { get => jueves; set => jueves = value; }
        public String Viernes { get => viernes; set => viernes = value; }
        public String Sabado { get => sabado; set => sabado = value; }
        public String Domingo { get => domingo; set => domingo = value; }
    }
}
