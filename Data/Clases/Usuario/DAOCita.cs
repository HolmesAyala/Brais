using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Administrador;
using Utilitaria.Clases.Usuario;

namespace Data.Clases.Usuario
{
    public class DAOCita
    {
        public DataTable reservarCita(ECita eCita)
        {
            DataTable dtCita = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_reservar_cita", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlTypes.NpgsqlDbType.Integer).Value = eCita.Id;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.EUsuario.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.Session;

                conexion.Open();
                dataAdapter.Fill(dtCita);
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

            return dtCita;
        }

        public DataTable obtenerCitasPacienteComentario(String id_usuario)
        {
            DataTable usuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_paciente_Comentario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = id_usuario;

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

        public DataTable citas_pendientes_pago(String id_user)
        {
            DataTable datos = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_no_pagadas", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usr", NpgsqlDbType.Text).Value = id_user;
                conexion.Open();
                dataAdapter.Fill(datos);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return datos;
        }

        public DataTable eliminarCita(ECita eCita)
        {
            DataTable dtCita = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_cita_paciente", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlTypes.NpgsqlDbType.Integer).Value = eCita.Id;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.EUsuario.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.Session;

                conexion.Open();
                dataAdapter.Fill(dtCita);
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

            return dtCita;
        }

        public DataTable obtenerCitasPaciente(String id_usuario)
        {
            DataTable usuario = new DataTable();

            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_paciente_cancel", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = id_usuario;

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

        public void act_cita(String id_user, int id_vieja_cita, int id_nueva_cita, String _session)
        {
            DataTable dtcita = new DataTable();
            EUsuario usr = new EUsuario();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_cita", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Integer).Value = id_nueva_cita;
                dataAdapter.SelectCommand.Parameters.Add("id_cita_old", NpgsqlDbType.Integer).Value = id_vieja_cita;
                dataAdapter.SelectCommand.Parameters.Add("id_user", NpgsqlDbType.Text).Value = id_user;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
                conexion.Open();
                dataAdapter.Fill(dtcita);
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

        public DataTable obtener_disp_tipo(int id)
        {
            DataTable dtcita = new DataTable();
            EUsuario usr = new EUsuario();
            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_seg_esp", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                conexion.Open();
                dataAdapter.Fill(dtcita);
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

            return dtcita;
        }

        public Boolean verificarDisponibilidadCita(int idCita)
        {
            DataTable dtCita = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_verificar_disponibilidad_cita", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = idCita;

                conexion.Open();
                dataAdapter.Fill(dtCita);
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

            return dtCita.Rows.Count > 0;
        }


        public DataTable obtenerCita(int idCita)
        {
            DataTable dtCita = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_cita", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = idCita;

                conexion.Open();
                dataAdapter.Fill(dtCita);
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

            return dtCita;
        }

        public DataTable obtenerCitas(int idEspecialidad, DateTime dia, EUsuario eUsuario)
        {
            DataTable dtCitas = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_especialidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEspecialidad;
                dataAdapter.SelectCommand.Parameters.Add("_dia", NpgsqlTypes.NpgsqlDbType.Date).Value = dia.Date;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eUsuario.Identificacion;

                conexion.Open();
                dataAdapter.Fill(dtCitas);
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

            return dtCitas;
        }

        public DataTable obtenerCitas(int idEspecialidad, EUsuario eUsuario)
        {
            DataTable dtCitas = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_especialidad", NpgsqlTypes.NpgsqlDbType.Integer).Value = idEspecialidad;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eUsuario.Identificacion;

                conexion.Open();
                dataAdapter.Fill(dtCitas);
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

            return dtCitas;
        }
    }
}
