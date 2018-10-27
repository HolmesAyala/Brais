using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using NpgsqlTypes;
using Utilitaria.Clases.Usuario;

/// <summary>
/// Descripción breve de DBCitasUsr
/// </summary>
public class DBCitasUsr
{
    public DBCitasUsr()
    {
        //
        // TODO: Agregar aquí la lógica del constructordsfsdafdfmmmdsfññ
        //
    }

    public DataTable obtener_citas_user(String id)
    {
        DataTable dtEps = new DataTable();
        EUsuario usr = new EUsuario();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_citas_paciente_usr", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value =id;
            conexion.Open();
            dataAdapter.Fill(dtEps);
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

        return dtEps;
    }

    public void activar_pago(String id_user,int id_cita, String _session)
    {
        DataTable datos = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_activar_pago", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = id_user;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Integer).Value = id_cita;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
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
    }

}