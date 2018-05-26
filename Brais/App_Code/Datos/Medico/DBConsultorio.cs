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

    public DataTable obtenerConsultorios()
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_obtener_consultorios", conexion);
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

    public DataTable obtenerConsultoriosDisponibles()
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_obtener_consultorios_disponibles", conexion);
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

    public DataTable guardarDisponibilidad(int id_consultorio, string _session)
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_guardar_disponibilidad", conexion);
            dataAdapter.SelectCommand.Parameters.Add("_id_consultorio", NpgsqlDbType.Integer).Value = id_consultorio;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
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

    public DataTable liberarDisponibilidad(int id_consultorio, string _session)
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_liberar_disponibilidad", conexion);
            dataAdapter.SelectCommand.Parameters.Add("_id_consultorio", NpgsqlDbType.Integer).Value = id_consultorio;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
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

    public DataTable obtenerConsultorio(int id_consultorio)
    {
        DataTable consultorio = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_obtener_consultorio", conexion);
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id_consultorio;
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

    public Boolean validar_consultorio(int id_consultorio) {
        DataTable validate = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try{
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_is_occupied_consul", conexion);
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id_consultorio;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dataAdapter.Fill(validate);

        }
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            conexion.Close();
        }
        if (validate.Rows.Count>0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool eliminar_consultorio(int id)
    {
        DataTable validate = new DataTable();

        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            if (validar_consultorio(id)) {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_delete_consultorio", conexion);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = "fdsaf3243";
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                dataAdapter.Fill(validate);
                return false;
            }
            else{
                //NO ES VALIDO
                return true;
            }
            
        }
        catch(Exception e)
        {
            throw e;
        }
        finally{
            conexion.Close();
        }

    }
}