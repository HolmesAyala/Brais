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
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = eMedico.Session;
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

    public DataTable eliminarMedico(string id, string _session)
    {
        DataTable resultado = new DataTable();

        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_eliminar_medico", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Text).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;

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

    public void crear_horario(EMedico medico)
    {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            if (schedule_is_already(medico.Identificacion))
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_update_horario_medico", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = medico.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_horario", NpgsqlDbType.Json).Value = medico.Horario;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Json).Value = medico.Session;
                dataAdapter.Fill(data);
            }
            else
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_insertar_horario", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = medico.Identificacion;
                dataAdapter.SelectCommand.Parameters.Add("_horario", NpgsqlDbType.Json).Value = medico.Horario;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Json).Value = medico.Session;
                conexion.Open();
                dataAdapter.Fill(data);
            }
           
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


    public bool schedule_is_already(String id)
    {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_horario_medico", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = id;
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
        if (data.Rows.Count == 0)
        {
            return false;
        }
        else return true;
    }
    //FUNCTION WHERE I GET THE SCHEDULE OF THE MEDIC BY EACH DAYS IN JSON
    public DataTable get_schedule(String id_medic) {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_horario_medico", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = id_medic;
            dataAdapter.Fill(data);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally {
            conexion.Close();
        }
        return data;
    }

    public DataTable get_schedule_organized(String id_medic)
    {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.f_obtener_horario_organizado", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_medic", NpgsqlDbType.Text).Value = id_medic;
            dataAdapter.Fill(data);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            conexion.Close();
        }
        return data;
    }

    public void delete_aux_schedule()
    {
        DataTable data = new DataTable();
        NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("medico.delete_aux_schedule", conexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.Fill(data);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            conexion.Close();
        }
    }


}