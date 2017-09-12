using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour {

    int iDBadge;
    Nivel nivel;
    string ruta;
    string descripcion;
    public Badge() { }

    public Badge(int iDBadge, Nivel nivel, string ruta, string descripcion)
    {
        this.iDBadge = iDBadge;
        this.nivel = nivel;
        this.ruta = ruta;
        this.descripcion = descripcion;
    }

    public int IDBadge
    {
        get
        {
            return iDBadge;
        }

        set
        {
            iDBadge = value;
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
