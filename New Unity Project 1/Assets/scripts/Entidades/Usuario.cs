using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Entidades
{
	public  class Usuario
    {
        int idUsuario;
        string ruta;
        string descripcion;

        public Usuario(int idUsuario, string ruta, string descripcion) {
            this.idUsuario = idUsuario;
            this.ruta = ruta;
            this.descripcion = descripcion;
        }

        public Usuario() {
        }





        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Ruta
        {
            get
            {
                return ruta;
            }

            set
            {
                ruta = value;
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
    }
}
