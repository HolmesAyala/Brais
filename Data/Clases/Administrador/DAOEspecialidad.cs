using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Clases.Administrador
{
    public class DAOEspecialidad
    {
        public DataTable obtenerTipoEspecialidad()
        {
            DataTable tipoEspecialidad = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_tipo_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                dataAdapter.Fill(tipoEspecialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return tipoEspecialidad;
        }

        public DataTable obtenerEspecialidad(int id)
        {
            DataTable dtEspecialidad = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                conexion.Open();
                dataAdapter.Fill(dtEspecialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return dtEspecialidad;
        }

        public Boolean hayUnMedicoConEstaEspecialidad(int id)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_hay_un_medico_con_esta_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                conexion.Open();
                dataAdapter.Fill(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return ((Boolean)resultado.Rows[0]["f_hay_un_medico_con_esta_especialidad"]);
        }

        public void eliminarEspecialidad(int id, string _session)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_eliminar_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = _session;

                conexion.Open();
                dataAdapter.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

        }

        public void actualizarEspecialidad(int id, string nombre, string _session)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_actualizar_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = _session;

                conexion.Open();
                dataAdapter.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void agregarEspecialidad(string nombre, string _session)
        {
            DataTable resultado = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_agregar_especialidad", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = _session;

                conexion.Open();
                dataAdapter.SelectCommand.ExecuteNonQuery();
                //dataAdapter.Fill(resultado);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }
}
