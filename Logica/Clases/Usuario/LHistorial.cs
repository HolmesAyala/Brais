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

        public List<ReporteHistorialMedico> cargarInformeHistorial(Object usuario)
        {
            DataTable informacionHistorial = new DataTable(); //dt
            DAOHistorial dAOHistorial = new DAOHistorial();
            EUsuario eUsuario = new EUsuario();
            eUsuario = (EUsuario)usuario;

            DataTable intermedio = dAOHistorial.obtenerHistorial(eUsuario.Identificacion);
            List<ReporteHistorialMedico> reporteHistorialMedicos = new List<ReporteHistorialMedico>(); 

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteHistorialMedico reporteHistorialMedico = new ReporteHistorialMedico();

                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(intermedio.Rows[i]["fecha"].ToString());
                reporteHistorialMedico.Fecha = Convert.ToString(fecha.ToShortDateString());
                if (intermedio.Rows[i]["motivo_consulta"].ToString().Equals(""))
                {
                    reporteHistorialMedico.MotivoConsulta = "No especifica";
                }
                else
                {
                    reporteHistorialMedico.MotivoConsulta = intermedio.Rows[i]["motivo_consulta"].ToString();
                }
                reporteHistorialMedico.Observacion = intermedio.Rows[i]["observacion"].ToString();
                reporteHistorialMedico.Especialidad = intermedio.Rows[i]["servicio"].ToString();
                reporteHistorialMedico.Medico = intermedio.Rows[i]["nombre_medico"].ToString();

                reporteHistorialMedicos.Add(reporteHistorialMedico);
            }

            return reporteHistorialMedicos;
        }
    }
}
