using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena : MonoBehaviour {

    int iDEscena;
    Nivel nivel;
    string descripcion;
    string ruta;
    int orden;
    public Escena() { }

    public Escena(int iDEscena, Nivel nivel, string descripcion, string ruta, int orden)
    {
        this.iDEscena = iDEscena;
        this.nivel = nivel;
        this.descripcion = descripcion;
        this.ruta = ruta;
        this.orden = orden;
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

    public Nivel Nivel
    {
        get
        {
            return nivel;
        }

        set
        {
            nivel = value;
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

    public int Orden
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
