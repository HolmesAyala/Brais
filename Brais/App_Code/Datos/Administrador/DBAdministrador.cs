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

    public void eliminarConsultorio(int id, string _session)
    {
        DataTable delete = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_delete_consultorio", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
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
    
}