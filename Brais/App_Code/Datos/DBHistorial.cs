using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBHistorial
/// </summary>
public class DBHistorial
{
    public DBHistorial()
    {

    }

    public static DataTable agregarHistorial(EHistorial eHistorial)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_agregar_historial", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.IdMedico;
            dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.IdUsuario;
            dataAdapter.SelectCommand.Parameters.Add("_motivo_consulta", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.MotivoConsulta;
            dataAdapter.SelectCommand.Parameters.Add("_observacion", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.Observacion;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlTypes.NpgsqlDbType.Date).Value = eHistorial.Fecha;
            dataAdapter.SelectCommand.Parameters.Add("_servicio", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.Servicio;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = eHistorial.Session;

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

        return resultado;
    }

    public DataTable obtenerHistorial(String idUsuario)
    {
        DataTable dtHistorial = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_historial", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = idUsuario;

            conexion.Open();
            dataAdapter.Fill(dtHistorial);
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

        return dtHistorial;
    }

}