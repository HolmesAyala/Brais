using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Administrador;
using Utilitaria.Clases;
using Data.Clases.Medico;
using Data.Clases;
using Data.Clases.Usuario;
using System.Data;
using Utilitaria.Clases.Medico;
using Utilitaria.Clases.Usuario;

namespace Logica.Clases.Usuario
{
    public class LCita
    {
        public void validarSession(Object eCita)
        {
            if (eCita == null)
            {
                throw new Exception();
                
            }
        }

        public DataTable eliminarCita(ECita eCita)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.eliminarCita(eCita);
        }

        public DataTable obtenerCitasPaciente(String id_usuario)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.obtenerCitasPaciente(id_usuario);
        }

        public ECita dataTableToECita(DataTable dtCita)
        {
            DataRow drCita = dtCita.Rows[0];
            DAOMedico dAOMedico = new DAOMedico();
            DAOUsuario dAOUsuario = new DAOUsuario();
            LFuncion funcion = new LFuncion();

            ECita eCita = new ECita();

            eCita.Id = int.Parse(drCita["id"].ToString());
            eCita.EMedico = funcion.dataTableToEMedico(dAOMedico.obtenerMedico(drCita["id_medico"].ToString()));
            eCita.EUsuario = funcion.dataTableToEUsuario(dAOUsuario.obtenerUsuario(drCita["id_usuario"].ToString()));
            eCita.HoraInicio = drCita["hora_inicio"].ToString();
            eCita.HoraFin = drCita["hora_fin"].ToString();
            eCita.Dia = drCita["dia"].ToString();

            return eCita;
        }

        public DataTable obtenerCita(int idCita)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.obtenerCita(idCita);
        }

        public DataTable obtenerCitas(int tipoCita, EUsuario eUsuario)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.obtenerCitas(tipoCita, eUsuario);
        }

        public List<ReporteCita> cargarInformeCitas(Object identificacionMedico)
        {
            DataTable informacionPacientes = new DataTable(); //dt
            List<ReporteCita> reporteCitas = new List<ReporteCita>();

            DAOUsuario dAOUsuario = new DAOUsuario();
            DataTable intermedio = new DataTable();
            if (identificacionMedico != null)
            {
                intermedio = dAOUsuario.obtenerPacientesAgendados(identificacionMedico.ToString());
            }

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteCita reporteCita = new ReporteCita();

                reporteCita.Hora = intermedio.Rows[i]["hora"].ToString();
                if (intermedio.Rows[i]["tipo_identificacion"].ToString().Equals("Cedula"))
                {
                    reporteCita.TipoIdentificación = "C.C";
                }
                else if (intermedio.Rows[i]["tipo_identificacion"].ToString().Equals("Tarjeta de identidad"))
                {
                    reporteCita.TipoIdentificación = "T.I";
                }
                reporteCita.Identificacion = intermedio.Rows[i]["identificacion"].ToString();
                reporteCita.Nombre = intermedio.Rows[i]["nombre"].ToString();
                reporteCita.Apellido = intermedio.Rows[i]["apellido"].ToString();

                reporteCitas.Add(reporteCita);
            }

            return reporteCitas;
        }

        public Boolean validarFecha(Object oFechasDisponibles, DateTime dateTime)
        {
            List<DateTime> fechasDisponibles = new List<DateTime>();

            if (oFechasDisponibles != null)
                fechasDisponibles = (List<DateTime>)oFechasDisponibles;

            foreach (DateTime fecha in fechasDisponibles)
            {
                if (dateTime == fecha)
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable mostrarDisponibilidadHoraria(int tipoCita, DateTime fechasDisponibles, EUsuario eUsuario)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.obtenerCitas(tipoCita, fechasDisponibles, eUsuario);
        }

        public Boolean verificarDisponibilidadCita(int idCita)
        {
            DAOCita dAOCita = new DAOCita();
            if (dAOCita.verificarDisponibilidadCita(idCita))
            {
                return dAOCita.verificarDisponibilidadCita(idCita);
            }
            else
            {
                return dAOCita.verificarDisponibilidadCita(idCita);
                throw new Exception("La cita ya se encuentra reservada!");
            }
        }

        public DataTable obtener_disp_tipo(int idCita)
        {
            DAOCita dAOCita = new DAOCita();
            if (dAOCita.obtener_disp_tipo(idCita).Rows.Count > 0)
            {
                return dAOCita.obtener_disp_tipo(idCita);
            }
            return null;
        }

        public void act_cita(String id_user, int id_vieja_cita, int id_nueva_cita, String _session)
        {
            DAOCita dAOCita = new DAOCita();
            dAOCita.act_cita(id_user, id_vieja_cita, id_nueva_cita, _session);
        }

        public Boolean validarCita(int id)
        {
            DataTable cita = new DataTable();
            LCita lCita = new LCita();
            cita = lCita.obtenerCita(id);
            DateTime fecha_actual = new DateTime();
            fecha_actual = DateTime.Now;
            String hora_cita, aux_fecha;
            DateTime dia_cita = new DateTime();
            dia_cita = DateTime.Parse(cita.Rows[0]["dia"].ToString());
            aux_fecha = Convert.ToString(dia_cita.ToShortDateString());
            hora_cita = cita.Rows[0]["hora_inicio"].ToString();
            aux_fecha = aux_fecha + " " + hora_cita;
            System.TimeSpan diferencia_dias = DateTime.Parse(aux_fecha).Subtract(fecha_actual);
            int dias = int.Parse(diferencia_dias.ToString("dd"));
            int horas = int.Parse(diferencia_dias.ToString("hh"));
            if (dias > 0)
            {
                return true;
            }
            else if (horas >= 6)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public DataTable citas_pendientes_pago(String id_user)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.citas_pendientes_pago(id_user);
        }

        public DataTable obtenerCitasPacienteComentario(String id_usuario)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.obtenerCitasPacienteComentario(id_usuario);
        }

        public DataTable reservarCita(ECita eCita)
        {
            DAOCita dAOCita = new DAOCita();
            return dAOCita.reservarCita(eCita);
        }

        public void activar_pago(String id_user, int id_cita, String _session)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            dAOUsuario.activar_pago(id_user, id_cita, _session);
        }

        public List<ReporteHistorialCitas> carharReporteCitas(Object usuario)
        {

            DataTable inf_medc = new DataTable();
            DAOCita dAOCita = new DAOCita();
            EUsuario eUsuario = (EUsuario)usuario;
            DataTable intermedio = dAOCita.obtener_all_cites(eUsuario.Identificacion);
            List<ReporteHistorialCitas> reporteHistorialCitas = new List<ReporteHistorialCitas>();

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteHistorialCitas reporteHistorialCita = new ReporteHistorialCitas();
                DateTime dia = DateTime.Parse(intermedio.Rows[i]["dia"].ToString());
                reporteHistorialCita.Fecha = Convert.ToString(dia.ToShortDateString());
                reporteHistorialCita.HoraInicio = intermedio.Rows[i]["hora_inicio"].ToString();
                reporteHistorialCita.HoraFin = intermedio.Rows[i]["hora_fin"].ToString();
                if (intermedio.Rows[i]["pago"].Equals(true))
                {
                    reporteHistorialCita.Pago = "Si";
                }
                else if (intermedio.Rows[i]["pago"].Equals(false))
                {
                    reporteHistorialCita.Pago = "No";
                }

                reporteHistorialCitas.Add(reporteHistorialCita);
            }
            return reporteHistorialCitas;
        }
    }
}
