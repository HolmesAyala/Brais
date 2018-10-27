using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Utilitaria.Clases.Medico;

/// <summary>
/// Descripción breve de DBMedico
/// </summary>
public class DBMedico
{
    public DBMedico()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtener_dias()
    {
        DataTable datos = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_dias",connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            dataAdapter.Fill(datos);

        }catch(Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        return datos;
    }

    public DataTable obtener_horas()
    {
        DataTable data = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_horas", connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            dataAdapter.Fill(data);

        }
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        return data;
    }

    public DataTable obtenerHoras_dia()
    {
        DataTable data = new DataTable();
        NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_horas_dia", connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            dataAdapter.Fill(data);

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        return data;
    }

    /**public void insertar_dias_de_trabajo(int id_dia,String id_medico)
    {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_insertar_dias_laborales", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_dia",NpgsqlDbType.Integer).Value = id_dia;
            dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = id_medico;
            conexion.Open();
            dataAdapter.Fill(data);
        }
        catch(Exception e)
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
        return;
    }**/
}