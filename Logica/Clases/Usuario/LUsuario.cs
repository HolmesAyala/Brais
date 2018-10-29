using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Clases.Usuario;
using Utilitaria.Clases.Usuario;

namespace Logica.Clases.Usuario
{
    public class LUsuario
    {
        public void validarUsuarioTipo(Object usuario)
        {
            if (usuario == null || ((EUsuario)usuario).TipoUsuario != 3)
            {
            }
            else
            {
                throw new Exception();
            }
        }

        public DataTable obtener_citas_user(String id)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.obtener_citas_user(id);
        }

        public void insertarActualizar(String accion, EUsuario eUsuario)
        {
            if (accion.Equals("Agregar"))
            {
                CrearUsuario(eUsuario);
            }
            else if (accion.Equals("Actualizar"))
            {
                actualizarUsuario(eUsuario);
            }
            else if (accion.Equals("Eliminar"))
            {

            }
        }

        public DataTable actualizarUsuario(EUsuario eUsuario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.actualizarUsuario(eUsuario);
        }

        public DataTable CrearUsuario(EUsuario eUsuario)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.CrearUsuario(eUsuario);
        }

        public DataTable obtenerUsuario(String identificacion)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.obtenerUsuario(identificacion);
        }

        public DataTable eliminarUsuario(string id, string SessionID)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            DataTable usuario = dAOUsuario.eliminarUsuario(id, SessionID);
            return usuario;
        }

        public void validarUsuario(Object IdentificacionMedico)
        {
            if (IdentificacionMedico == null)
            {
                throw new Exception("Acceso denegado");
            }
        }

        public DataTable obtenerPacientesAgendados(Object IdentificacionMedico)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.obtenerPacientesAgendados(IdentificacionMedico.ToString());
        }

        public DataTable buscarUsuario(string id)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            DataTable usuario = dAOUsuario.buscarUsuario(id);
            return usuario;
        }

        public Boolean verificarUsuario(String identificacion)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.verificarUsuario(identificacion);
        }

        public Boolean validarExistenciaCorreo(string correo)
        {
            DAOUsuario dAOUsuario = new DAOUsuario();
            return dAOUsuario.validarExistenciaCorreo(correo);
        }

        public Boolean validarDatos(String accion, Object identificacion, EUsuario eUsuario, String nombreAfiliacion, String repetirClave)
        {
            String mensaje = "";

            if (eUsuario.Tipo_id == 0)
            {
                mensaje += "- No ha seleccionado un tipo de documento<br/>";
            }

            if (eUsuario.Identificacion.Equals(""))
            {
                mensaje += "- El campo Numero de documento esta vacio<br/>";
            }
            else
            {

                if (accion.Equals("Agregar") && !verificarUsuario((eUsuario.Identificacion)))
                {
                    mensaje += "- YA EXISTE UN USUARIO CON ESA IDENTIFICACION<br/>";
                }

                if (identificacion != null)
                {
                    string id = identificacion.ToString();
                    LFuncion lFuncion = new LFuncion();
                    EUsuario usuario = lFuncion.dataTableToEUsuario(obtenerUsuario(id));

                    if (accion.Equals("Actualizar") &&
                         usuario.Identificacion != eUsuario.Identificacion &&
                         !verificarUsuario((eUsuario.Identificacion)))
                    {
                        mensaje += "- YA EXISTE UN USUARIO CON ESA IDENTIFICACION<br/>";
                    }
                }

                try
                {
                    int.Parse(eUsuario.Identificacion);
                }
                catch (Exception)
                {
                    mensaje += "- El numero de documento solo debe incluir numeros<br/>";
                }
            }

            if (eUsuario.Nombre.Equals(""))
            {
                mensaje += "- El campo nombre esta vacio<br/>";
            }
            if (eUsuario.Apellido.Equals(""))
            {
                mensaje += "- El campo apellido esta vacio<br/>";
            }

            if (eUsuario.Fecha.Equals(""))
            {
                mensaje += "- No ha seleccionado fecha de nacimiento<br/>";
            }
            else if (Convert.ToDateTime(eUsuario.Fecha) > DateTime.Now)
            {
                mensaje += "- Su fecha de nacimiento debe <br/>  ser menor a la fecha actual<br/>";
            }

            if (eUsuario.Tipo_afiliacion == 0)
            {
                mensaje += "- No ha seleccionado el tipo de afiliacion<br/>";
            }
            else if (nombreAfiliacion.Equals("E.P.S.") && eUsuario.IdEps == 0)
            {
                mensaje += "- No ha seleccionado su E.P.S.<br/>";
            }

            if (eUsuario.Correo.Equals(""))
            {
                mensaje += "- El campo correo esta vacio<br/>";
            }
            else if (!validarExistenciaCorreo(eUsuario.Correo) && accion.Equals("Agregar"))
            {
                mensaje += "- El correo ya se encuentra registrado<br/>";
            }
            else if (identificacion != null)
            {
                string id = identificacion.ToString();

                LUsuario lUsuario = new LUsuario();
                LFuncion lFuncion = new LFuncion();

                EUsuario usuario = lFuncion.dataTableToEUsuario(obtenerUsuario(id));

                if (accion.Equals("Actualizar") &&
                     usuario.Correo != eUsuario.Correo &&
                     !validarExistenciaCorreo((eUsuario.Correo)))
                {
                    mensaje += "- El correo ya se encuentra registrado<br/>";
                }
            }

            if (eUsuario.Password.Equals("") || repetirClave.Equals(""))
            {
                mensaje += "- Los campos de contraseña estan vacios<br/>";
            }
            else if (!eUsuario.Password.Equals(repetirClave))
            {
                mensaje += "- Las contraseñas no coinciden<br/>";
            }

            if (!mensaje.Equals(""))
            {
                throw new Exception();
            }
        }
    }
}
