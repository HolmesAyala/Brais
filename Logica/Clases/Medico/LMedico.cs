using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Clases.Medico;
using Data.Clases.Usuario;
using Data.Clases.Administrador;
using Data.Clases;
using Utilitaria.Clases.Medico;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Administrador;
using Newtonsoft.Json;

namespace Logica.Clases.Medico
{
    public class LMedico
    {
        public void validarMedico(EUsuario eUsuario, EMedico eMedico)
        {
            if (eMedico == null && eUsuario == null)
            {
                throw new Exception("Usuarios no validos");
            }
        }

        public void validarTipoMedico(Object eUsuario, int tipoUsuario)
        {
            if (eUsuario == null || tipoUsuario != 2)
            {
            }
            else
            {
                throw new Exception();
            }
        }

        public DataTable buscarMedico(String id)
        {
            DAOMedico dAOMedico = new DAOMedico();
            DataTable medico = dAOMedico.buscarMedico(id);
            return medico;
        }

        public DataTable obtenerMedico(String identificacion)
        {
            DAOMedico dAOMedico = new DAOMedico();
            DataTable medico = dAOMedico.obtenerMedico(identificacion);
            return medico;
        }

        public DataTable eliminarMedico(string id, string SessionID)
        {
            DAOMedico dAOMedico = new DAOMedico();
            DataTable medico = dAOMedico.eliminarMedico(id, SessionID);
            return medico;
        }

        public void delete_aux_schedule()
        {
            DAOMedico dAOMedico = new DAOMedico();
            dAOMedico.delete_aux_schedule();
        }

        public List<ReporteHorario> cargarInformeHorario(String idMedico)
        {
            List<ReporteHorario> reporteHorarios = new List<ReporteHorario>();
            DAOMedico dAOMedico = new DAOMedico();
            DataTable datos = dAOMedico.get_schedule_organized(idMedico);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ReporteHorario reporteHorario = new ReporteHorario();

                reporteHorario.Lunes = datos.Rows[i]["lunes"].ToString();
                reporteHorario.Martes = datos.Rows[i]["martes"].ToString();
                reporteHorario.Miercoles = datos.Rows[i]["miercoles"].ToString();
                reporteHorario.Jueves = datos.Rows[i]["jueves"].ToString();
                reporteHorario.Viernes = datos.Rows[i]["viernes"].ToString();

                reporteHorarios.Add(reporteHorario);
            }

            return reporteHorarios;
        }

        public ReporteHorario get_schedule(String id_medic)
        {
            DAOMedico dAOMedico = new DAOMedico();
            DataTable data = dAOMedico.get_schedule(id_medic);
            ReporteHorario reporteHorario = new ReporteHorario();
            if (data.Rows.Count > 0)
            {
                EDia[] Lun, mar, mier, juev, vier, sab = null;

                ESemana sem;
                sem = JsonConvert.DeserializeObject<ESemana>(data.Rows[0]["horario"].ToString());
                List<String> horar = new List<string>();
                if (sem.Lunes != null)
                {
                    reporteHorario.Lunes = "Lunes";
                    Lun = new EDia[sem.Lunes.Count];
                    String aux = "";
                    for (int i = 0; i < sem.Lunes.Count; i++)
                    {
                        Lun[i] = JsonConvert.DeserializeObject<EDia>(sem.Lunes.ElementAt<String>(i));
                        aux = aux + Lun[i].Hora_inicio + "-" + Lun[i].Hora_fin + "</br>";
                    }
                    reporteHorario.Lunes = aux;
                }
                if (sem.Martes != null)
                {
                    reporteHorario.Martes = "Martes";
                    mar = new EDia[sem.Martes.Count];
                    String aux = "";
                    for (int i = 0; i < mar.Length; i++)
                    {
                        mar[i] = JsonConvert.DeserializeObject<EDia>(sem.Martes.ElementAt<String>(i));
                        aux = aux + mar[i].Hora_inicio + "-" + mar[i].Hora_fin + "</br>";
                    }
                    reporteHorario.Martes = aux;
                }
                if (sem.Miercoles != null)
                {
                    reporteHorario.Miercoles = "Miercoles";
                    mier = new EDia[sem.Miercoles.Count];
                    String aux = "";
                    for (int i = 0; i < mier.Length; i++)
                    {
                        mier[i] = JsonConvert.DeserializeObject<EDia>(sem.Miercoles.ElementAt<String>(i));
                        aux = aux + mier[i].Hora_inicio + "-" + mier[i].Hora_fin + "</br>";
                    }
                    reporteHorario.Miercoles = aux;

                }
                if (sem.Jueves != null)
                {
                    juev = new EDia[sem.Jueves.Count];
                    String aux = "";
                    reporteHorario.Jueves = "Jueves";
                    for (int i = 0; i < juev.Length; i++)
                    {
                        juev[i] = JsonConvert.DeserializeObject<EDia>(sem.Jueves.ElementAt<String>(i));
                        aux = aux + juev[i].Hora_inicio + "-" + juev[i].Hora_fin + "</br>";
                    }
                    reporteHorario.Jueves = aux;
                }
                if (sem.Viernes != null)
                {
                    reporteHorario.Viernes = "Viernes";
                    String aux = "";
                    vier = new EDia[sem.Viernes.Count];
                    for (int i = 0; i < vier.Length; i++)
                    {
                        vier[i] = JsonConvert.DeserializeObject<EDia>(sem.Viernes.ElementAt<String>(i));
                        aux = aux + vier[i].Hora_inicio + "-" + vier[i].Hora_fin + "</br>";
                    }
                    reporteHorario.Viernes = aux;
                }
                if (sem.Sabado != null)
                {
                    sab = new EDia[sem.Sabado.Count];
                    String aux = "";
                    for (int i = 0; i < sab.Length; i++)
                    {
                        sab[i] = JsonConvert.DeserializeObject<EDia>(sem.Sabado.ElementAt<String>(i));
                        aux = aux + sab[i].Hora_inicio + "-" + sab[i].Hora_fin + "</br>";
                    }
                }
            }
            else
            {
                throw new Exception("No Hay Creado Su Horario De Trabajo");
            }
            return reporteHorario;
        }

        public void crear_horario(EMedico medico)
        {
            DAOMedico dAOMedico = new DAOMedico();
            dAOMedico.crear_horario(medico);
        }

        public String pintarHorarioMedico(ESemana eSemana)
        {
            String pinta_horar = "";
            if (eSemana.Lunes != null)
            {
                pinta_horar = pinta_horar + "LUNES";
                for (int i = 0; i < eSemana.Lunes.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Lunes.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            if (eSemana.Martes != null)
            {
                pinta_horar = pinta_horar + "MARTES";
                for (int i = 0; i < eSemana.Martes.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Martes.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            if (eSemana.Miercoles != null)
            {
                pinta_horar = pinta_horar + "MIERCOLES";
                for (int i = 0; i < eSemana.Miercoles.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Miercoles.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            if (eSemana.Jueves != null)
            {
                pinta_horar = pinta_horar + "JUEVES";
                for (int i = 0; i < eSemana.Jueves.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Jueves.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            if (eSemana.Viernes != null)
            {
                pinta_horar = pinta_horar + "VIERNES";
                for (int i = 0; i < eSemana.Viernes.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Viernes.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            if (eSemana.Sabado != null)
            {
                pinta_horar = pinta_horar + "SABADO";
                for (int i = 0; i < eSemana.Sabado.Count; i++)
                {
                    pinta_horar = pinta_horar + "</br>" + obtener_hora(eSemana.Sabado.ElementAt(i));
                }
                pinta_horar = pinta_horar + "</br></br>";
            }
            String mensaje = pinta_horar;
            return mensaje;
        }

        private String obtener_hora(String dia)
        {
            String res = "";
            EDia day = JsonConvert.DeserializeObject<EDia>(dia);
            res = res + day.Hora_inicio + "-" + day.Hora_fin;
            return res;
        }

        public ESemana validarSemana(object obj)
        {
            ESemana eSemana;
            if (obj == null)
            {
                eSemana = new ESemana();
            }
            else
            {
                eSemana = (ESemana)obj;
            }
            return eSemana;
        }

        public ESemana crearActividadSemanal(EDia[] day, String dia, ESemana eSemana)
        {
            if (day != null)
            {
                switch (dia)
                {
                    case "Lunes":
                        for (int i = 0; i < day.Length; i++)
                        {
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            if (eSemana.Lunes == null) eSemana.crear_lunes();
                            eSemana.Lunes.Add(aux);
                        }
                        break;
                    case "Martes":
                        for (int i = 0; i < day.Length; i++)
                        {
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            if (eSemana.Martes == null) eSemana.crear_Martes();
                            eSemana.Martes.Add(aux);
                        }
                        break;
                    case "Miercoles":
                        for (int i = 0; i < day.Length; i++)
                        {
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            if (eSemana.Miercoles == null) eSemana.crear_Miercoles();
                            eSemana.Miercoles.Add(aux);
                        }
                        break;
                    case "Jueves":
                        for (int i = 0; i < day.Length; i++)
                        {
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            if (eSemana.Jueves == null) eSemana.crear_Jueves();
                            eSemana.Jueves.Add(aux);
                        }
                        break;
                    case "Viernes":
                        for (int i = 0; i < day.Length; i++)
                        {
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            if (eSemana.Viernes == null) eSemana.crear_Viernes();
                            eSemana.Viernes.Add(aux);
                        }
                        break;
                    case "Sabado":
                        for (int i = 0; i < day.Length; i++)
                        {
                            if (eSemana.Sabado == null) eSemana.crear_Sabado();
                            String aux = JsonConvert.SerializeObject((EDia)day[i]);
                            eSemana.Sabado.Add(aux);
                        }
                        break;
                }
            }
            return eSemana;
        }

        private String crear_cadena_dias(EDia[] dias)
        {
            String cadena = "";
            for (int i = 0; i < dias.Length; i++)
            {
                cadena = cadena + dias[i].Hora_inicio + "-";
                cadena = cadena + dias[i].Hora_fin + "</br>";
            }
            return cadena;
        }

        private EDia[] llenar_eDias(String[] json)
        {
            List<EDia> day = new List<EDia>();
            for (int i = 0; i < json.Length; i++)
            {
                EDia aux = JsonConvert.DeserializeObject<EDia>(json[i]);
                day.Add(aux);
            }
            return day.ToArray();
        }

        public String mostrar_datos(ESemana eSemana)
        {
            String dias = "";
            if (eSemana.Lunes != null)
            {
                dias = dias + " Lunes " + "</br>";
                String[] d = eSemana.Lunes.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            if (eSemana.Martes != null)
            {
                dias = dias + " Martes " + "</br>";
                String[] d = eSemana.Martes.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            if (eSemana.Miercoles != null)
            {
                dias = dias + " Miercoles " + "</br>";
                String[] d = eSemana.Miercoles.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            if (eSemana.Jueves != null)
            {
                dias = dias + " Jueves " + "</br>";
                String[] d = eSemana.Jueves.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            if (eSemana.Viernes != null)
            {
                dias = dias + " Viernes " + "</br>";
                String[] d = eSemana.Viernes.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            if (eSemana.Sabado != null)
            {
                dias = dias + " Sabado " + "</br>";
                String[] d = eSemana.Sabado.ToArray();
                EDia[] di = llenar_eDias(d);
                dias = dias + crear_cadena_dias(di) + "</br>";
            }
            return dias;
        }

        public void validate(Boolean validate)
        {
            if (!validate)
            {
                throw new Exception();
            }
        }

        public void validarDDL(String ddlInicial, String ddlFinal)
        {
            if (ddlInicial == "---------" || ddlFinal == "---------")
            {
                throw new Exception("Debe Seleccionar Un Dato Para La H.inicial y H.final");
                
            }
        }

        public void validarRango(Object rango)
        {
            if (rango != null)
            {
                throw new Exception();
            }
        }

        public void validarDias(Object and_day, String ddlDias)
        {
            if ((String)and_day != ddlDias)
            {
            }
            else
            {
                throw new Exception();
            }
        }

        public EDia[] insertar_after(EDia[] aux, EDia[] dias)
        {
            for (int i = 0; i < aux.Length; i++)
            {
                dias[i] = aux[i];
            }
            return dias;
        }

        public String pintar_rango(EDia[] dias)
        {
            String cadena = "";

            for (int i = 0; i < dias.Length; i++)
            {
                cadena = cadena + dias[i].Hora_inicio + "-";
                cadena = cadena + dias[i].Hora_fin + "</br>";
            } 

            return cadena;
        }

        public void validarRango(int va_inicio, int va_fin, Object rangoSes, EDia[] rang)
        {

            if (va_inicio >= va_fin)
            {
                //ERROR
                throw new Exception("<script type='text/javascript'>alert('El Rango Insertado No es Valido')</script>;");
            }
            else
            {
                if (rangoSes != null)
                {
                    for (int i = 0; i < rang.Length; i++)
                    {
                        int va_in_old = DateTime.Parse(rang[i].Hora_inicio).Hour;
                        int va_fi_old = DateTime.Parse(rang[i].Hora_fin).Hour;
                        if (va_inicio == va_fin)
                        {
                            throw new Exception("<script type='text/javascript'>alert('El Rango Insertado No Es Valido')</script>;");
                        }
                        if (va_fi_old > va_inicio)
                        {
                            if (va_inicio < va_in_old)
                            {
                                if (va_fin >= va_fi_old)
                                {
                                    throw new Exception("<script type='text/javascript'>alert('El Rango Insertado Ya Se Encuentra en Otro Rango')</script>;");
                                }
                            }
                            else
                            {
                                //ERROR
                                throw new Exception("<script type='text/javascript'>alert('El Rango Insertado Ya Se Encuentra en Otro Rango')</script>;");
                                
                            }
                        }
                    }
                }
            }
        }

        public ESemana eliminarDias(String delete_day, Object semana)
        {
            ESemana sem = new ESemana();
            if (semana != null)
            {
                sem = (ESemana)semana;
                switch (delete_day)
                {
                    case "Lunes":
                        sem.Lunes = null;
                        break;
                    case "Martes":
                        sem.Martes = null;
                        break;
                    case "Miercoles":
                        sem.Miercoles = null;
                        break;
                    case "Jueves":
                        sem.Jueves = null;
                        break;
                    case "Viernes":
                        sem.Viernes = null;
                        break;
                }
            }
            return sem;
        }

        public EMedico adecuarParaActualizar(String identificacion)
        {
            DAOMedico dAOMedico = new DAOMedico();
            LFuncion funcion = new LFuncion();
            EMedico eMedico = new EMedico();

            eMedico = funcion.dataTableToEMedico(dAOMedico.obtenerMedico(identificacion));
            return eMedico;
        }

        public void validarTipoDocumento(int tipoDocumento)
        {
            if (tipoDocumento == 0)
            {
                throw new Exception("- No ha seleccionado un tipo de documento.<br/>");
            }
        }

        public void validarDDLEspecialidad(String especialidad)
        {
            if (especialidad == "Ninguno")
            {
                throw new Exception("- No ha seleccionado la especialidad.<br/>");
            }
        }

        public void validarNumeroDocumentoVacio(String identificacion)
        {
            if (identificacion.Equals(""))
            {
                throw new Exception("- El campo Numero de documento esta vacio.<br/>");
            }
        }

        public void validarnueroIdentificacion(String identificacionW, String accion, Object identificacionMedico)
        {
            String mensaje = "";
            DAOUsuario dAOUsuario = new DAOUsuario();
            DAOMedico dAOMedico = new DAOMedico();
            LFuncion funcion = new LFuncion();

            if (accion.Equals("Agregar") && dAOUsuario.verificarUsuario(identificacionW))
            {
                mensaje += "- YA EXISTE UN MÉDICO CON ESA IDENTIFICACION.<br/>";
            }

            if (identificacionMedico != null)
            {
                string identificacion = identificacionMedico.ToString();

                EMedico eMedico = funcion.dataTableToEMedico(dAOMedico.obtenerMedico(identificacionW));

                if (accion.Equals("Actualizar") &&
                     eMedico.Identificacion != identificacionW &&
                     !dAOUsuario.verificarUsuario((identificacionW)))
                {
                    mensaje += "- YA EXISTE UN USUARIO CON ESA IDENTIFICACION<br/>";
                }
            }

            try
            {
                int.Parse(identificacionW);
            }
            catch (Exception)
            {
                mensaje += "- El numero de documento solo debe incluir numeros.<br/>";
            }

            if (mensaje != "")
            {
                throw new Exception(mensaje);
            }
        }

        public void validarDatos(EMedico eMedico, String accion, Object identificacionMedico, String repetirContrasena)
        {
            String mensaje = "";
            DAOUsuario dAOUsuario = new DAOUsuario();
            if (eMedico.Nombre.Equals(""))
            {
                mensaje += "- El campo nombre esta vacio.<br/>";
            }
            if (eMedico.Apellido.Equals(""))
            {
                mensaje += "- El campo apellido esta vacio.<br/>";
            }

            if (eMedico.FechaNacimiento.Equals(""))
            {
                mensaje += "- No ha seleccionado fecha de nacimiento.<br/>";
            }
            else if (Convert.ToDateTime(eMedico.FechaNacimiento) > DateTime.Now)
            {
                mensaje += "- Su fecha de nacimiento debe <br/>  ser menor a la fecha actual.<br/>";
            }

            if (eMedico.Correo.Equals(""))
            {
                mensaje += "- El campo correo esta vacio.<br/>";
            }
            else if (!dAOUsuario.validarExistenciaCorreo(eMedico.Correo) && accion.Equals("Agregar"))
            {
                mensaje += "- El correo ya se encuentra registrado.<br/>";
            }
            else if (identificacionMedico != null)
            {
                string identificacion =identificacionMedico.ToString();

                DAOMedico dAOMedico = new DAOMedico();
                LFuncion funcion = new LFuncion();
                EMedico medico = funcion.dataTableToEMedico(dAOMedico.obtenerMedico(identificacion));

                if (accion.Equals("Actualizar") &&
                     medico.Correo != eMedico.Correo &&
                     !dAOUsuario.validarExistenciaCorreo((eMedico.Correo)))
                {
                    mensaje += "- El correo ya se encuentra registrado<br/>";
                }
            }

            if (eMedico.Password.Equals("") || repetirContrasena.Equals(""))
            {
                mensaje += "- Los campos de contraseña estan vacios.<br/>";
            }
            else if (!eMedico.Password.Equals(repetirContrasena))
            {
                mensaje += "- Las contraseñas no coinciden.<br/>";
            }

            if (mensaje != "")
            {
                throw new Exception(mensaje);
            }
        }

        public void guardarMedico(EMedico eMedico, String accion, Object consultorio, String SessionID)
        {
            DAOMedico dAOMedico = new DAOMedico();
            DAOConsultorio dAOConsultorio = new DAOConsultorio();

            if (accion.Equals("Agregar"))
            {
                dAOMedico.CrearMedico(eMedico);
                if (eMedico.Consultorio != Convert.ToInt32(consultorio))
                {
                    dAOConsultorio.guardarDisponibilidad(eMedico.Consultorio, SessionID);
                    dAOConsultorio.liberarDisponibilidad(Convert.ToInt32(consultorio), SessionID);
                }
                else if (eMedico.Consultorio == Convert.ToInt32(consultorio))
                {
                    dAOConsultorio.guardarDisponibilidad(eMedico.Consultorio, SessionID);
                }

            }
            else if (accion.Equals("Actualizar"))
            {
                dAOMedico.actualizarMedico(eMedico);
                if (eMedico.Consultorio != Convert.ToInt32(consultorio))
                {
                    dAOConsultorio.guardarDisponibilidad(eMedico.Consultorio, SessionID);
                    dAOConsultorio.liberarDisponibilidad(Convert.ToInt32(consultorio), SessionID);
                }
                else if (eMedico.Consultorio == Convert.ToInt32(consultorio))
                {
                    dAOConsultorio.guardarDisponibilidad(eMedico.Consultorio, SessionID);
                }
            }
        }
    }
}
