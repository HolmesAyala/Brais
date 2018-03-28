using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBTipoIdentificacion
/// </summary>
public class DBTipoIdentificacion
{
    public DBTipoIdentificacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtenerTipoIdentificacion()
    {
        DataTable tipoIdentificacion = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_tipo_identificacion", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            dataAdapter.Fill(tipoIdentificacion);
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

        return tipoIdentificacion;
    }

}