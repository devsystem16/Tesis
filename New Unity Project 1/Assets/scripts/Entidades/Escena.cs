using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.SqliteClient;
using System.Data;


public class Escena : Nivel {

    int iDEscena;
    string descripcion;
    string ruta;
    int orden;
    public Escena() { }

    public Escena(int iDEscena,   string descripcion, string ruta, int orden)
    {
        this.iDEscena = iDEscena;
   
        this.descripcion = descripcion;
        this.ruta = ruta;
        this.orden = orden;
    }


    public   void cargar(string prametro_nombreEscena_or_Id) {
   
        MyDBConnection oCnn = new MyDBConnection();
        oCnn.conectar();
        IDataReader odr = oCnn.select(ControllerSQL.escena_cargarEscena(prametro_nombreEscena_or_Id));

        if (odr != null)
        {
            while (odr.Read())
            {
                this.iDEscena = odr.GetInt32(0);
                this.IdNivel = odr.GetInt32(1);
                this.descripcion = odr.GetString(2);
                this.ruta = odr.GetString(3);
                this.orden = odr.GetInt32(4);
            }
        } // fin if
        if (odr != null)
        {
            if (!odr.IsClosed)
                odr.Close();
        }
        oCnn.cerrar();

    }

    public int IDEscena
    {
        get
        {
            return iDEscena;
        }

        set
        {
            iDEscena = value;
        }
    }

  

    public string DescripcionEscena
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

    public int OrdenEscena
    {
        get
        {
            return orden;
        }

        set
        {
            orden = value;
        }
    }
}
