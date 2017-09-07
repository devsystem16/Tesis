using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Entidades
{
	public   class Partida
    {
        int idPartida;
        Usuario usuario;
        string descripcion;
        string fecha;

        public Partida( int idPartida , Usuario usuario , string descripcion , string fecha) {
            this.idPartida = idPartida;
            this.usuario = usuario;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }

        public Partida() { }

        public int IdPartida
        {
            get
            {
                return idPartida;
            }

            set
            {
                idPartida = value;
            }
        }

        internal Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
    }
}
