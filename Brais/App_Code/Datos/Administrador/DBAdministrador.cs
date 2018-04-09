
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
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
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("f_obtener_consultorios",conection);
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

}