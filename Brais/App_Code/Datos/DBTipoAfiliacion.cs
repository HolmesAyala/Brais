using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBTipoAfiliacion
/// </summary>
public class DBTipoAfiliacion
{
    public DBTipoAfiliacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtenerTipoAfiliacion()
    {
        DataTable tipoAfiliacion = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_tipo_afiliacion", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            dataAdapter.Fill(tipoAfiliacion);
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

        return tipoAfiliacion;
    }

}