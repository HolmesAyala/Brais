using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBLogin
/// </summary>
public class DBLogin
{
    public DBLogin()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataTable Login(EUsuario informacion)
    {
        DataTable usuario = new DataTable();
        //Se Utiliza la libreria Configuration para no hacer SQL Quemado y crear la conexion a la BD
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.login", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = informacion.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = informacion.Password;

            conexion.Open();
            dataAdapter.Fill(usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conexion != null)
            {
                conexion.Close();
            }
        }
        return usuario;
    }

}