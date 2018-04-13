using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

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

    public DataTable CrearMedico(EMedico eMedico)
    {
        DataTable new_file = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.crear_medico", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_tipo_identificacion", NpgsqlDbType.Integer).Value = eMedico.TipoIdentificacion;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = eMedico.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = eMedico.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = eMedico.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = eMedico.FechaNacimiento;
            dataAdapter.SelectCommand.Parameters.Add("_id_especialidad", NpgsqlDbType.Integer).Value = eMedico.TipoEspecialidad;
            dataAdapter.SelectCommand.Parameters.Add("_consultorio_pk", NpgsqlDbType.Integer).Value = eMedico.Consultorio;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = eMedico.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = eMedico.Password;
            dataAdapter.SelectCommand.Parameters.Add("_tipo", NpgsqlDbType.Integer).Value = 2;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = "000";

            conection.Open();
            dataAdapter.Fill(new_file);
        }
        catch (Exception Ex)
        {
            if (Ex.Message == "23505: llave duplicada viola restricción de unicidad «usuario_correo_key»")
            {
                //Muestro el error
                DataTable error = new DataTable();
                error.Columns.Add("error");
                DataRow data = error.NewRow();
                data["error"] = "error";
                error.Rows.Add(data);
                return error;

            }
            else throw Ex;

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

    public DataTable actualizarMedico(EMedico eMedico)
    {
        DataTable resultado = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_actualizar_medico", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_tipo_identificacion", NpgsqlDbType.Integer).Value = eMedico.TipoIdentificacion;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = eMedico.Identificacion;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = eMedico.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Text).Value = eMedico.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = eMedico.FechaNacimiento;
            dataAdapter.SelectCommand.Parameters.Add("_id_especialidad", NpgsqlDbType.Integer).Value = eMedico.TipoEspecialidad;
            dataAdapter.SelectCommand.Parameters.Add("_consultorio_pk", NpgsqlDbType.Integer).Value = eMedico.Consultorio;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text).Value = eMedico.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_contrasena", NpgsqlDbType.Text).Value = eMedico.Password;
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


    public DataTable buscarMedico(string id)
    {
        DataTable usuario = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_buscar_medico", conection);
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

    public DataTable obtenerMedico(String identificacion)
    {
        DataTable medico = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_obtener_medico", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_identificacion", NpgsqlDbType.Text).Value = identificacion;

            conection.Open();
            dataAdapter.Fill(medico);
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
        return medico;
    }

    public DataTable eliminarMedico(string id)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_medico", conection);
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