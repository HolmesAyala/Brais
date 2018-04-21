using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using NpgsqlTypes;
using System.Linq;
using System.Web;
using System.Configuration;
/// <summary>
/// Descripción breve de DBAdministrador 
/// </summary>
public class DBAdministrador
{
    public DBAdministrador()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable obtenerConsultorios()
    {
        DataTable consultorios = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_obtener_consultorios", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conection.Open();
            dataAdapter.Fill(consultorios);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return consultorios;
    }

    public void insertarConsultorio(EConsultorio consul)
    {
        DataTable consultorios = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_crear_consultorio", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_ubicacion", NpgsqlDbType.Text).Value = consul.Ubicacion;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = consul.Session;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = consul.Nombre;
            conection.Open();
            dataAdapter.Fill(consultorios);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }

    }

    public DataTable obtenerConsultorio(int id)
    {
        DataTable consultorio = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_consultorio", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
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

    public void eliminarConsultorio(int id)
    {
        DataTable delete = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_delete_consultorio", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
            conexion.Open();
            dataAdapter.Fill(delete);
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
        return;
    }
    //Funcion para traer las duraciones de citas posibles para programar en el sistema cabe recalcar que solo aplica a partir de las citas nuevas
    public DataTable traerTiempos()
    {
        DataTable datos = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("administrador.f_obtener_horarios", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dataAdapter.Fill(datos);

        }catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conexion != null)
            {
                conexion.Close();
            }
        }
        return datos;
    }

    //FUNCION PARA SETEAR EL NUEVO PARAMETRO SE VA A CREAR EN LA TABLA POR LO TANTO EL PARAMETRO ACTUAL SERA SIEMPRE EL ULTIMO REGISTRO
    public DataTable actualizar_param (int fk_parametro)
    {
        DataTable actu = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_parametro", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_fk_actual", NpgsqlDbType.Integer).Value = fk_parametro;
            conexion.Open();
            dataAdapter.Fill(actu);
        }catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conexion != null)
            {
                conexion.Close();
            }
        }
        return actu;
    }


}