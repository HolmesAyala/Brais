using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBEspecialidad
/// </summary>
public class DBEspecialidad
{
    public DBEspecialidad()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

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

}