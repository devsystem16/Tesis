using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
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
