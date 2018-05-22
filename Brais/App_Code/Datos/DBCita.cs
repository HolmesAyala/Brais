using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBCita
/// </summary>
public class DBCita
{
    public DBCita()
    {

    }

    public static DataTable obtenerCita(int idCita)
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

    public static DataTable obtenerCitas(int idEspecialidad, EUsuario eUsuario)
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

    public static DataTable obtenerCitas(int idEspecialidad, DateTime dia, EUsuario eUsuario)
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

    public static Boolean verificarDisponibilidadCita(int idCita)
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

    public static DataTable reservarCita(ECita eCita)
    {
        DataTable dtCita = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_reservar_cita", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlTypes.NpgsqlDbType.Integer).Value = eCita.Id;
            dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.EUsuario.Identificacion;

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
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_paciente", conection);
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

    public static DataTable eliminarCita(ECita eCita)
    {
        DataTable dtCita = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_cita_paciente", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlTypes.NpgsqlDbType.Integer).Value = eCita.Id;
            dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eCita.EUsuario.Identificacion;

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

}