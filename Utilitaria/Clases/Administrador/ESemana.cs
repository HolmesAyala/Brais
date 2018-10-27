using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ESemana
/// </summary>
/// 

namespace Utilitaria.Clases.Administrador
{
    public class ESemana
    {
        private List<String> lunes, martes, miercoles, jueves, viernes, sabado, domingo;

        public void crear_lunes()
        {
            lunes = new List<string>();
        }

        public void crear_Martes()
        {
            martes = new List<string>();
        }
        public void crear_Miercoles()
        {
            miercoles = new List<string>();
        }
        public void crear_Jueves()
        {
            jueves = new List<string>();
        }
        public void crear_Viernes()
        {
            viernes = new List<string>();
        }
        public void crear_Sabado()
        {
            sabado = new List<string>();
        }


        public List<string> Lunes
        {
            get
            {
                return lunes;
            }

            set
            {
                lunes = value;
            }
        }

        public List<string> Martes
        {
            get
            {
                return martes;
            }

            set
            {
                martes = value;
            }
        }

        public List<string> Miercoles
        {
            get
            {
                return miercoles;
            }

            set
            {
                miercoles = value;
            }
        }

        public List<string> Jueves
        {
            get
            {
                return jueves;
            }

            set
            {
                jueves = value;
            }
        }

        public List<string> Viernes
        {
            get
            {
                return viernes;
            }

            set
            {
                viernes = value;
            }
        }

        public List<string> Sabado
        {
            get
            {
                return sabado;
            }

            set
            {
                sabado = value;
            }
        }

        public List<string> Domingo
        {
            get
            {
                return domingo;
            }

            set
            {
                domingo = value;
            }
        }
    }
}