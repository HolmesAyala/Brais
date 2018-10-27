using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Utilitaria.Clases.Usuario;
using Utilitaria.Clases.Medico;

/// <summary>
/// Descripción breve de ECita
/// </summary>
/// 

namespace Utilitaria.Clases.Administrador
{
    public class ECita
    {

        private int id;

        private EMedico eMedico;

        private EUsuario eUsuario;

        private string horaInicio;

        private string horaFin;

        private string dia;

        private string session;


        public ECita()
        {

        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string HoraInicio
        {
            get
            {
                return horaInicio;
            }

            set
            {
                horaInicio = value;
            }
        }

        public string HoraFin
        {
            get
            {
                return horaFin;
            }

            set
            {
                horaFin = value;
            }
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

        public EMedico EMedico
        {
            get
            {
                return eMedico;
            }

            set
            {
                eMedico = value;
            }
        }

        public EUsuario EUsuario
        {
            get
            {
                return eUsuario;
            }

            set
            {
                eUsuario = value;
            }
        }

        public string Session
        {
            get
            {
                return session;
            }

            set
            {
                session = value;
            }
        }
    }
}