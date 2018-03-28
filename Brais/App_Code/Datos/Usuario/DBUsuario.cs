using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using NpgsqlTypes;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Descripción breve de DBUsuario
/// </summary>
public class DBUsuario
{
    //Funcion Para Crear un New File
    public DataTable CrearUsuario(EUsuario eUsuario)
    {
        DataTable new_file = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.crear_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = eUsuario.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_name", NpgsqlDbType.Text).Value = eUsuario.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_lastname", NpgsqlDbType.Text).Value = eUsuario.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_tipoafiliacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_afiliacion;
            dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = eUsuario.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Text).Value = eUsuario.Password;
            dataAdapter.SelectCommand.Parameters.Add("_tipoid", NpgsqlDbType.Integer).Value = eUsuario.Tipo_id;
            dataAdapter.SelectCommand.Parameters.Add("_date", NpgsqlDbType.Date).Value = eUsuario.Fecha;
            conection.Open();
            dataAdapter.Fill(new_file);
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
        return new_file;
    }

    public DataTable actualizarUsuario(EUsuario eUsuario)
    {
        DataTable resultado = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = eUsuario.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_id_tipo_identificacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_id;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = eUsuario.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = eUsuario.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = eUsuario.Fecha;
            dataAdapter.SelectCommand.Parameters.Add("_id_tipo_afiliacion", NpgsqlDbType.Integer).Value = eUsuario.Tipo_afiliacion;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = eUsuario.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = eUsuario.Password;
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

    public DataTable obtenerUsuario(String identificacion)
    {
        DataTable usuario = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = identificacion;

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

    public DataTable buscarUsuario(string id)
    {
        DataTable usuario = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_buscar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = id;

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

    public DataTable eliminarUsuario(string id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = id;

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

}