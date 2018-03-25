using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBFunciones
/// </summary>
public class DBRecuperarContrasena
{
    public DBRecuperarContrasena()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable restablecerContrasena(string identificacion, string contrasena)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_restablecer_contrasena", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion_usuario", NpgsqlDbType.Text).Value = identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = contrasena;

            conection.Open();
            dataAdapter.Fill(resultado);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return resultado;
    }

    public DataTable verificarExistenciaSolicitud(String identificacion)
    {
        DataTable solicitud = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_verificar_existencia_solicitud", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = identificacion;

            conection.Open();
            dataAdapter.Fill(solicitud);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return solicitud;
    }

    public DataTable agregarSolicitudDeRestablecerContrasena(string identificacionUsuario, string token)
    {
        DataTable solicitud = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_agregar_solicitud_de_restablecer_contrasena", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion_usuario", NpgsqlDbType.Text).Value = identificacionUsuario;
            dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;

            conection.Open();
            dataAdapter.Fill(solicitud);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return solicitud;
    }

    public DataTable obtenerSolicitud(string token)
    {
        DataTable solicitud = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_solicitud", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;

            conection.Open();
            dataAdapter.Fill(solicitud);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return solicitud;
    }

    public DataTable obtenerSolicitudValida(string token)
    {
        DataTable solicitud = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_solicitud_valida", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_token", NpgsqlDbType.Text).Value = token;

            conection.Open();
            dataAdapter.Fill(solicitud);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return solicitud;
    }

    public DataTable eliminarSolicitud(String identificacion)
    {
        DataTable usuario = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_solicitud", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion_usuario", NpgsqlDbType.Text).Value = identificacion;

            conection.Open();
            dataAdapter.Fill(usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return usuario;
    }

}