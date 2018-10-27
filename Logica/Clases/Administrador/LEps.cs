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
    public class LEps
    {
        public DataTable obtenerEps()
        {
            DAOEps dAOEps = new DAOEps();
            return dAOEps.obtenerEps();
        }

        public List<ListItem> llenarDDLEps()
        {
            DAOEps dAOEps = new DAOEps();
            List<ListItem> listItems = new List<ListItem>();

            foreach (DataRow fila in dAOEps.obtenerEps().Rows)
            {
                ListItem listItem = new ListItem(fila["nombre"].ToString(), fila["id"].ToString());
                listItems.Add(listItem);
            }
            return listItems;
        }

        public void agregarEps(String eps, String SessionID)
        {
            if (!eps.Equals(""))
            {
                DAOEps dAOEps = new DAOEps();
                dAOEps.agregarEps(eps, SessionID);
            }
            else
            {
                throw new Exception("Campo vacio!");
            }
        }

        public void actualizarEps(int id, string nombre, String SessionID)
        {
            if (!nombre.Equals(""))
            {
                DAOEps dAOEps = new DAOEps();
                dAOEps.actualizarEps(id, nombre, SessionID);
            }
            else
            {
                throw new Exception("El nombre que va a actualizar esta vacio!");
            }
        }

        public void eliminarEps(int id)
        {
            DAOEps dAOEps = new DAOEps();
            if (!dAOEps.hayUnUsuarioConEstaEps(id))
            {
                dAOEps.eliminarEps(id);
            }
            else
            {
                throw new Exception("Hay usuarios registrados con esa eps!");
            }
        }
    }
}
