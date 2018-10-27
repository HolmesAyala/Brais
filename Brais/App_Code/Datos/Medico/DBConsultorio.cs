using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBConsultorio
/// </summary>
public class DBConsultorio
{
    public DBConsultorio()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtenerConsultorio(String nombre_consultorio)
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_obtener_consultorio", conexion);
            dataAdapter.SelectCommand.Parameters.Add("_nombre_consultorio", NpgsqlDbType.Text).Value = nombre_consultorio;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            dataAdapter.Fill(consultorio);
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

        return consultorio;
    }
}