using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.SqliteClient;
namespace Assets.scripts.Entidades
{
	public   class Partida : Usuario
    {
        int idPartida;
         
        string descripcion;
        string fecha;

        public Partida( int idPartida , string descripcion , string fecha) {
            this.idPartida = idPartida;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }

        public Partida() { }


        public   void cargarPartida( object IDUsuario)
        {

            int IDpartida = Usuario.obtenerIDPartida(IDUsuario);

            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.partida_cargarPartidaByid(IDpartida));
            if (odr != null)
            {
                while (odr.Read())
                {
                    this.idPartida = odr.GetInt16(0);
                    this.IdUsuario = odr.GetInt32(1);
                    this.descripcion = odr.GetString(2);
                    this.fecha = odr.GetString(3);

                }
            } // fin if
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();
 
        }
        public   string nivel(string opcion) {
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.sql_cargarNivel(opcion,IdUsuario));

            string nivel = "";
            if (odr.Read())
            {
                nivel = odr.GetString(3);
            }
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();
            return  (nivel  != "")? nivel :  ControllerSQL.nivelDefecto;
        }

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
 

        public string DescripcionPartida
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
