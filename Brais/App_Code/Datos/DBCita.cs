using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Administrador;

/// <summary>
/// Descripción breve de DBCita
/// </summary>
public class DBCita
{
    public DBCita()
    {

    }

    public DataTable obtener_all_cites(String id)
    {
        DataTable dtCita = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_paciente_all", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlTypes.NpgsqlDbType.Text).Value = id;

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