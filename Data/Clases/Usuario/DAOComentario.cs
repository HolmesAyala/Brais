using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Usuario;

namespace Data.Clases.Usuario
{
    public class DAOComentario
    {
        public DataTable guardarComentario(EComentario eComentario)
        {
            DataTable dtComentario = new DataTable();

            NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("public.f_agregar_comentario", conexion);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_motivo", NpgsqlTypes.NpgsqlDbType.Integer).Value = eComentario.Id_motivo;
                dataAdapter.SelectCommand.Parameters.Add("_comentario", NpgsqlTypes.NpgsqlDbType.Text).Value = eComentario.Comentario;
                dataAdapter.SelectCommand.Parameters.Add("_id_remitente", NpgsqlTypes.NpgsqlDbType.Text).Value = eComentario.Id_remitente;
                dataAdapter.SelectCommand.Parameters.Add("_id_receptor", NpgsqlTypes.NpgsqlDbType.Text).Value = eComentario.Id_receptor;
                dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlTypes.NpgsqlDbType.Integer).Value = eComentario.Id_cita;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlTypes.NpgsqlDbType.Text).Value = eComentario.Session;
                conexion.Open();
                dataAdapter.Fill(dtComentario);
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

            return dtComentario;
        }
    }
}
