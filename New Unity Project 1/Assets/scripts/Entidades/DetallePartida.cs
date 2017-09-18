using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using System.Data;
using Mono.Data.SqliteClient;
public class DetallePartida : MonoBehaviour {

    int iDDetallePartida;
    Partida partida;
    Escena escena ;
    decimal porcentajeEfectividad;
    public DetallePartida() { }

    public DetallePartida(int iDDetallePartida, Partida partida, Escena escena, decimal porcentajeEfectividad)
    {
        this.iDDetallePartida = iDDetallePartida;
        this.partida = partida;
        this.escena = escena;
        this.porcentajeEfectividad = porcentajeEfectividad;
    }


    public  static bool guardar(int idPartida, int idEscena , double porcentaje ) {

        if (!existe(idPartida, idEscena)) {
            string sql = "insert into DetallePartida (IDPartida, IDEscena, PorcentajeEfectividad , fecha) values (" + idPartida + " , " + idEscena + ", " + porcentaje + "   ,   date('now') )";

            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
                         
            if (oCnn.insertar(sql) != -1)
                return true;
            else return false;
        }
        return false;

    }

    public static bool existe( int partida , int escena)
    {
        bool existe = false;
        MyDBConnection oCnn = new MyDBConnection();
        oCnn.conectar();
        IDataReader odr = oCnn.select(" select  * from DetallePartida  where IDPartida = "+ partida + " and IDEscena = "+ escena + " ");
        if (odr != null)
            if (odr.Read())
                existe = true;
        if (odr != null)
            if (!odr.IsClosed)
                odr.Close();
        oCnn.cerrar();

        return existe;
    }

    public int IDDetallePartida
    {
        get
        {
            return iDDetallePartida;
        }

        set
        {
            iDDetallePartida = value;
        }
    }

    public Partida Partida
    {
        get
        {
            return partida;
        }

        set
        {
            partida = value;
        }
    }

    public Escena Escena
    {
        get
        {
            return escena;
        }

        set
        {
            escena = value;
        }
    }

    public decimal PorcentajeEfectividad
    {
        get
        {
            return porcentajeEfectividad;
        }

        set
        {
            porcentajeEfectividad = value;
        }
    }
}
