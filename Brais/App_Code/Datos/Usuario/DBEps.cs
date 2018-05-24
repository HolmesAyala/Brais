using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBEps
/// </summary>
public class DBEps
{
    public DBEps()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtenerEps()
    {
        DataTable dtEps = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_eps", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

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

    public static Boolean hayUnUsuarioConEstaEps(int id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("eps.f_hay_un_usuario_con_esta_eps", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

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

        return ((Boolean)resultado.Rows[0]["f_hay_un_usuario_con_esta_eps"]);
    }

    public static void agregarEps(string nombre, string _session)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("eps.f_agregar_eps", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = _session;

            conexion.Open();
            dataAdapter.SelectCommand.ExecuteNonQuery();
            //dataAdapter.Fill(resultado);
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

    }

    public static void actualizarEps(int id, string nombre, String _session)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("eps.f_actualizar_eps", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = _session;

            conexion.Open();
            dataAdapter.SelectCommand.ExecuteNonQuery();
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

    }

    public static void eliminarEps(int id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("eps.f_eliminar_eps", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

            conexion.Open();
            dataAdapter.SelectCommand.ExecuteNonQuery();
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

    }
}