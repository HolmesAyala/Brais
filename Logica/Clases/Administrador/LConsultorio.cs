using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Clases.Administrador;
using Data.Clases.Administrador;
using System.Data;
using System.Web.UI.WebControls;
using Utilitaria.Clases.Administrador;

namespace Logica.Clases.Administrador
{
    public class LConsultorio
    {
        public ListItem cargarConsultoriosDisponibles()
        {
            DAOConsultorio dAOConsultorio = new DAOConsultorio();
            ListItem listItem = new ListItem();
            foreach (DataRow fila in dAOConsultorio.obtenerConsultoriosDisponibles().Rows)
            {
                listItem = new ListItem(fila["nombre_consultorio"].ToString(), fila["id"].ToString());
            }

            return listItem;
        }

        public void eliminar_consultorio(int id)
        {
            DAOConsultorio dAOConsultorio = new DAOConsultorio();
            bool is_copuied = dAOConsultorio.eliminar_consultorio(id);
            if (is_copuied == true)
            {
                throw new Exception("No ha ingresado datos.");
            }
        }

        public void liberarDisponibilidad(int id_consultorio, string SessionID)
        {
            DAOConsultorio dAOConsultorio = new DAOConsultorio();
            dAOConsultorio.liberarDisponibilidad(id_consultorio, SessionID);
        }

        public DataRow obtenerConsultorio(int id_consultorio)
        {
            DAOConsultorio dAOConsultorio = new DAOConsultorio();

            DataRow consultorio = dAOConsultorio.obtenerConsultorio(id_consultorio).Rows[0];

            return consultorio;
        }

        public List<ReporteConsultorios> cargarInformeConsultorios()
        {
            List<ReporteConsultorios> reporteConsultorios = new List<ReporteConsultorios>();
            
            DAOConsultorio dAOConsultorio = new DAOConsultorio();

            DataTable intermedio = dAOConsultorio.obtenerConsultorios();

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                ReporteConsultorios reporteConsultorio = new ReporteConsultorios();

                reporteConsultorio.Nombre = intermedio.Rows[i]["nombre_consultorio"].ToString();
                reporteConsultorio.Ubicacion = intermedio.Rows[i]["ubicacion"].ToString();
                if (intermedio.Rows[i]["disponibilidad"].Equals(true))
                {
                    reporteConsultorio.Disponible = "No";
                }
                else if (intermedio.Rows[i]["disponibilidad"].Equals(false) || intermedio.Rows[i]["disponibilidad"].Equals(null))
                {
                    reporteConsultorio.Disponible = "Si";
                }

                reporteConsultorios.Add(reporteConsultorio);
            }

            return reporteConsultorios;
        }
    }
}
