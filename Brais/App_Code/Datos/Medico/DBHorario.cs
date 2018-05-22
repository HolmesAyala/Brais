using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBHorario
/// </summary>
public class DBHorario
{
    public DBHorario()
    {

    }

    public static DataTable obtenerHorario(EMedico eMedico)
    {
        DataTable horario = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_horario", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Text).Value = eMedico.Identificacion;

            conexion.Open();
            dataAdapter.Fill(horario);
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

        return horario;
    }

    public static DataTable actualizarHorario(EMedico eMedico)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_horario", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medico", NpgsqlDbType.Text).Value = eMedico.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_dias", NpgsqlDbType.Text).Value = eMedico.Horario;

            conexion.Open();
            dataAdapter.Fill(resultado);
        }
        catch (Exception e)
        {
            //throw e;
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

}