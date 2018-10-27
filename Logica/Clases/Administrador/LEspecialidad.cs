using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Data.Clases.Administrador;

namespace Logica.Clases.Administrador
{
    public class LEspecialidad
    {
        public DataTable obtenerEspecialidad(int id)
        {
            DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
            DataTable especialidad = dAOEspecialidad.obtenerEspecialidad(id);
            return especialidad;
        }

        public void agregarEspecialidad(String especialidad, String SessionID)
        {
            if (!especialidad.Equals(""))
            {
                DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
                dAOEspecialidad.agregarEspecialidad(especialidad, SessionID);
            }
            else
            {
                throw new Exception("Campo vacio");
            }
        }

        public void actualizarEspecialidad(int id, string nombre, string SessionID)
        {
            if (!nombre.Equals(""))
            {
                DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
                dAOEspecialidad.actualizarEspecialidad(id, nombre, SessionID);
            }
            else
            {
                throw new Exception("El nombre que va a actualizar esta vacio!");
            }
        }

        public void eliminarEspecialidad(int id, string SessionID)
        {
            DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
            if (!dAOEspecialidad.hayUnMedicoConEstaEspecialidad(id))
            {
                dAOEspecialidad.eliminarEspecialidad(id, SessionID);
            }
            else
            {
                throw new Exception("Hay medicos registrados con esa especialidad!");
            }
        }

        public ListItem cargarEspecialidades()
        {
            DAOEspecialidad dAOEspecialidad = new DAOEspecialidad();
            ListItem listItem = new ListItem();
            int contador = 0;
            foreach (DataRow fila in dAOEspecialidad.obtenerTipoEspecialidad().Rows)
            {
                listItem = new ListItem(fila["nombre"].ToString(), fila["id"].ToString());
                contador++;
            }
            return listItem;
        }
    }
}
