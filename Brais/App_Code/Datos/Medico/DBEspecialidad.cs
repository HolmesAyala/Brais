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

    public static Boolean hayUnMedicoConEstaEspecialidad(int id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_hay_un_medico_con_esta_especialidad", conexion);
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

        return ((Boolean)resultado.Rows[0]["f_hay_un_medico_con_esta_especialidad"]);
    }

    public static void agregarEspecialidad(string nombre)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_agregar_especialidad", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;

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

    public static void actualizarEspecialidad(int id, string nombre)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_actualizar_especialidad", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;

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

    public static void eliminarEspecialidad(int id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("especialidad.f_eliminar_especialidad", conexion);
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