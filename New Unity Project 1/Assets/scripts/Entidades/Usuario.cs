﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.SqliteClient;
using System.Data;
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
        public Usuario()
        { }

        public static int obtenerIDPartida(object IDusuario)
        {
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.usuario_obtenerCodigoPartida(IDusuario));
            int IDpartida = -1;
            if (odr != null)
            {
                if (odr.Read())
                {
                    IDpartida = odr.GetInt16(0);
                }
            }
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();

            return IDpartida;
        }

        public static int obtenerIdNivelActual(object IDusuario)
        {
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.usuario_nivelActual(IDusuario));
            int IDpartida = -1;
            if (odr != null)
            {
                if (odr.Read())
                {
                    IDpartida = odr.GetInt16(0);
                }
            }
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();

            return IDpartida;
        }

        public Usuario cargar() {
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.usuario_consultarUsuario(this.idUsuario));
            if (odr != null) {
                while (odr.Read())
                {
                    this.idUsuario = odr.GetInt32(0);
                    this.ruta = odr.GetString(1);
                    this.descripcion = odr.GetString(2);
                }
            } // fin if
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();

            return this;
        }


        public   string nivel(string opcion )
        {
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            System.Data.IDataReader odr = oCnn.select(ControllerSQL.sql_cargarNivel(opcion , this.idUsuario));

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
            return nivel;
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
