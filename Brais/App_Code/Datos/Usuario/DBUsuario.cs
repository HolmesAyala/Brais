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
    public DataTable CrearUsuario(EUsuario user)
    {
        DataTable new_file = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.crear_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = user.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_name", NpgsqlDbType.Text).Value = user.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_lastname", NpgsqlDbType.Text).Value = user.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_tipoafiliacion", NpgsqlDbType.Integer).Value = user.Tipo_afiliacion;
            dataAdapter.SelectCommand.Parameters.Add("_email", NpgsqlDbType.Text).Value = user.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_password", NpgsqlDbType.Text).Value = user.Password;
            dataAdapter.SelectCommand.Parameters.Add("_tipoid", NpgsqlDbType.Integer).Value = user.Tipo_id;
            dataAdapter.SelectCommand.Parameters.Add("_date", NpgsqlDbType.Date).Value = user.Fecha;
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
}