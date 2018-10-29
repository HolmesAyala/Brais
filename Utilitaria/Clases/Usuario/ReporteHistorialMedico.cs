using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaria.Clases.Usuario
{
    public class ReporteHistorialMedico
    {
        private String fecha;

        private String motivoConsulta;

        private String observacion;

        private String especialidad;

        private String medico;

        public string Fecha { get => fecha; set => fecha = value; }
        public string MotivoConsulta { get => motivoConsulta; set => motivoConsulta = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Medico { get => medico; set => medico = value; }
    }
}
