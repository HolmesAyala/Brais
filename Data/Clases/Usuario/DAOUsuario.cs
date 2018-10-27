using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Usuario;

namespace Data.Clases.Usuario
{
    public class DAOUsuario
    {
        public DataTable actualizarUsuario(EUsuario eUsuario)
        {
            DataTable resultado = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = eUsuario.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_id_tipo_identificacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = eUsuario.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = eUsuario.Apellido;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = eUsuario.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_id_tipo_afiliacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_afiliacion;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = eUsuario.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = eUsuario.Password;
                dataAdapter.SelectCommand.Parameters.Add("_id_eps", NpgsqlDbType.Integer).Value = eUsuario.IdEps;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = eUsuario.Session;
                conection.Open();
                dataAdapter.Fill(resultado);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return resultado;
        }

        public DataTable CrearUsuario(EUsuario eUsuario)
        {
            DataTable new_file = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.crear_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = eUsuario.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_name", NpgsqlDbType.Text).Value = eUsuario.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_lastname", NpgsqlDbType.Text).Value = eUsuario.Apellido;
                dataAdapter.SelectCommand.Parameters.Add("_tipoafiliacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_afiliacion;
                dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = eUsuario.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Text).Value = eUsuario.Password;
                dataAdapter.SelectCommand.Parameters.Add("_tipoid", NpgsqlDbType.Integer).Value = eUsuario.Tipo_id;
                dataAdapter.SelectCommand.Parameters.Add("_date", NpgsqlDbType.Date).Value = eUsuario.Fecha;
                dataAdapter.SelectCommand.Parameters.Add("_tipo", NpgsqlDbType.Integer).Value = 3;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = "000";
                dataAdapter.SelectCommand.Parameters.Add("_id_eps", NpgsqlDbType.Integer).Value = eUsuario.IdEps;
                conection.Open();
                dataAdapter.Fill(new_file);
            }
            catch (Exception Ex)
            {
                if (Ex.Message == "23505: llave duplicada viola restricción de unicidad «usuario_correo_key»")
                {
                    //Muestro el error
                    DataTable error = new DataTable();
                    error.Columns.Add("error");
                    DataRow data = error.NewRow();
                    data["error"] = "error";
                    error.Rows.Add(data);
                    return error;

                }
                else throw Ex;

            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return new_file;
        }

        public DataTable obtenerPacientesAgendados(String id_medico)
        {
            DataTable usuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_buscar_pacientes_agendados", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Text).Value = id_medico;

                conection.Open();
                dataAdapter.Fill(usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return usuario;
        }

        public DataTable obtenerUsuario(String identificacion)
        {
            DataTable usuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = identificacion;

                conection.Open();
                dataAdapter.Fill(usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return usuario;
        }

        public Boolean validarExistenciaCorreo(string correo)
        {
            DataTable dtUsuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_validar_existencia_correo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = correo;

                conection.Open();
                dataAdapter.Fill(dtUsuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return dtUsuario.Rows.Count == 0;
        }

        public Boolean verificarUsuario(String identificacion)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_verificar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = identificacion;

                conection.Open();
                dataAdapter.Fill(resultado);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return resultado.Rows.Count == 0;
        }

        public DataTable buscarUsuario(string id)
        {
            DataTable usuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_buscar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = id;

                conection.Open();
                dataAdapter.Fill(usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return usuario;
        }

        public DataTable eliminarUsuario(string id, string _session)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;

                conection.Open();
                dataAdapter.Fill(resultado);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return resultado;
        }
    }
}
