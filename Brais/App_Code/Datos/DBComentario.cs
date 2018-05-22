using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBComentario
/// </summary>
public class DBComentario
{
    public DBComentario()
    {
    }

    public static DataTable guardarComentario(EComentario eComentario)
    {
        DataTable dtComentario = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_agregar_comentario", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = idCita;

            conexion.Open();
            dataAdapter.Fill(dtComentario);
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

        return dtComentario;
    }

}