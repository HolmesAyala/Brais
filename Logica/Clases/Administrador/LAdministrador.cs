using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaria.Clases.Administrador;
using Data.Clases.Administrador;
using Utilitaria.Clases.Usuario;
using Data.Clases.Medico;
using Data.Clases.Usuario;

namespace Logica.Clases.Administrador
{
    public class LAdministrador
    {
        public void validarUsuario(EUsuario eUsuario)
        {
            if (eUsuario == null || eUsuario.TipoUsuario != 1)
            {
                throw new Exception("Usuario Invalido");
            }
        }

        public DataTable obtenerConsultorio(int id)
        {
            DAOAdministrador dAOAdministrador = new DAOAdministrador();
            return dAOAdministrador.obtenerConsultorio(id);
        }

        public DataTable obtenerConsultorios()
        {
            DAOAdministrador dAOAdministrador = new DAOAdministrador();
            return dAOAdministrador.obtenerConsultorios();
        }

        public String param_actual(Boolean IsPostBack)
        {
            DAOAdministrador dAOAdministrador = new DAOAdministrador();
            DataTable informacion = dAOAdministrador.param_actual();
            String value = informacion.Rows[0]["info"].ToString();
            if (informacion.Rows.Count > 0)
            {
                if (IsPostBack)
                {
                    throw new Exception();
                }
            }
            return value;
        }

        public void insertarConsultorio(EConsultorio eConsultorio)
        {
            if ((eConsultorio.Nombre.ToString().Trim() == "") || (eConsultorio.Ubicacion.ToString().Trim() == ""))
            {
                throw new Exception("Espacios en blanco");
            }
            else
            {
                DAOAdministrador dAOAdministrador = new DAOAdministrador();
                dAOAdministrador.insertarConsultorio(eConsultorio);
            }
        }

        public void actualizar_param(int fk_parametro, String sesion)
        {
            DAOAdministrador dAOAdministrador = new DAOAdministrador();
            dAOAdministrador.actualizar_param(fk_parametro, sesion);
        }

        public List<ReporteMedico> cargarReporteMedicos()
        {
            DataTable inf_medc = new DataTable();
            List<ReporteMedico> reporteMedicos = new List<ReporteMedico>();
            DAOMedico dbme = new DAOMedico();
            DataTable intermedio = dbme.buscarMedico("");
            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteMedico reporteMedico = new ReporteMedico();

                reporteMedico.Identificacion = intermedio.Rows[i]["identificacion"].ToString();
                reporteMedico.Nombre = intermedio.Rows[i]["nombre"].ToString();
                reporteMedico.Apellido = intermedio.Rows[i]["apellido"].ToString();
                reporteMedico.Correo = intermedio.Rows[i]["correo"].ToString();
                reporteMedicos.Add(reporteMedico);
            }
            return reporteMedicos;
        }

        public List<ReporteUsuario> cargarInformeUsuarios()
        {
            DataTable informacionUsuarios = new DataTable(); //dt
            List<ReporteUsuario> reporteUsuarios = new List<ReporteUsuario>();

            DAOUsuario dBUsuario = new DAOUsuario();

            DataTable intermedio = dBUsuario.buscarUsuario("");

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteUsuario reporteUsuario = new ReporteUsuario();

                reporteUsuario.Identificacion = intermedio.Rows[i]["identificacion"].ToString();
                if (intermedio.Rows[i]["nombre_identificacion"].ToString().Equals("Cedula"))
                {
                    reporteUsuario.Tipo = "C.C";
                }
                else if (intermedio.Rows[i]["nombre_identificacion"].ToString().Equals("Tarjeta de identidad"))
                {
                    reporteUsuario.Tipo = "T.I";
                }
                reporteUsuario.Nombre = intermedio.Rows[i]["nombre"].ToString();
                reporteUsuario.Apellido = intermedio.Rows[i]["apellido"].ToString();
                reporteUsuario.Afiliacion = intermedio.Rows[i]["nombre_afiliacion"].ToString();
                reporteUsuario.Correo = intermedio.Rows[i]["correo"].ToString();

                reporteUsuarios.Add(reporteUsuario);
            }

            return reporteUsuarios;
        }
    }
}
