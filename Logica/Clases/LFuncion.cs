using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Medico;
using Utilitaria.Clases.Administrador;
using Data.Clases.Medico;
using Data.Clases.Administrador;
using System.Text.RegularExpressions;

namespace Logica.Clases
{
    public class LFuncion
    {
        public void validarPaginaAnterior(Object obj)
        {
            if (obj != null)
            {
                throw new Exception();
            }
        }

        public string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public EUsuario dataTableToEUsuario(DataTable dtUsuario)
        {
            EUsuario eUsuario = new EUsuario();

            try
            {
                eUsuario.Identificacion = dtUsuario.Rows[0]["identificacion"].ToString();
                eUsuario.Tipo_id = int.Parse(dtUsuario.Rows[0]["id_tipo_identificacion"].ToString());
                eUsuario.Nombre = dtUsuario.Rows[0]["nombre"].ToString();
                eUsuario.Apellido = dtUsuario.Rows[0]["apellido"].ToString();
                eUsuario.Fecha = dtUsuario.Rows[0]["fecha_nacimiento"].ToString();
                eUsuario.Tipo_afiliacion = int.Parse(dtUsuario.Rows[0]["id_tipo_afiliacion"].ToString());
                eUsuario.Correo = dtUsuario.Rows[0]["correo"].ToString();
                eUsuario.Password = dtUsuario.Rows[0]["contrasena"].ToString();
                eUsuario.TipoUsuario = int.Parse(dtUsuario.Rows[0]["tipo"].ToString());
                eUsuario.IdEps = int.Parse(dtUsuario.Rows[0]["id_eps"].ToString());
            }
            catch (Exception)
            {
                return null;
                //throw;
            }

            return eUsuario;
        }

        public EMedico dataTableToEMedico(DataTable dtMedico)
        {
            EMedico eMedico = new EMedico();
            DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
            DAOHorario dAOHorario = new DAOHorario();
            try
            {
                eMedico.Identificacion = dtMedico.Rows[0]["identificacion"].ToString();
                eMedico.TipoIdentificacion = int.Parse(dtMedico.Rows[0]["id_tipo_identificacion"].ToString());
                eMedico.Nombre = dtMedico.Rows[0]["nombre"].ToString();
                eMedico.Apellido = dtMedico.Rows[0]["apellido"].ToString();
                eMedico.FechaNacimiento = dtMedico.Rows[0]["fecha_nacimiento"].ToString();
                eMedico.TipoEspecialidad = int.Parse(dtMedico.Rows[0]["id_especialidad"].ToString());
                eMedico.Correo = dtMedico.Rows[0]["correo"].ToString();
                eMedico.Password = dtMedico.Rows[0]["contrasena"].ToString();
                eMedico.TipoUsuario = int.Parse(dtMedico.Rows[0]["tipo"].ToString());
                eMedico.Consultorio = int.Parse(dtMedico.Rows[0]["consultorio_pk"].ToString());
                eMedico.EEspecialidad = EEspecialidad.dataTableToEEspecialidad(dAOEspecialidad.obtenerEspecialidad(int.Parse(dtMedico.Rows[0]["id_especialidad"].ToString())));
                DataTable dt = dAOHorario.obtenerHorario(eMedico);
                eMedico.Horario = dt.Rows[0]["dias"].ToString();
            }
            catch (Exception)
            {
                return null;
                //throw;
            }

            return eMedico;
        }

        public Boolean tieneCaracteresEspeciales(string texto)
        {
            Regex regex = new Regex(@"^[\s\w]*$");
            return !regex.IsMatch(texto);
        }
    }
}
