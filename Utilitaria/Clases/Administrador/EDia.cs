using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EDia
/// </summary>
/// 

namespace Utilitaria.Clases.Administrador
{
    public class EDia
    {
        private String dia, hora_inicio, hora_fin;
        public EDia()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public string Dia
        {
            get
            {
                return dia;
            }

            set
            {
                dia = value;
            }
        }

        public string Hora_inicio
        {
            get
            {
                return hora_inicio;
            }

            set
            {
                hora_inicio = value;
            }
        }

        public string Hora_fin
        {
            get
            {
                return hora_fin;
            }

            set
            {
                hora_fin = value;
            }
        }
    }
}
