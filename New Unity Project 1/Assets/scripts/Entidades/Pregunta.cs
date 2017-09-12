using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta : MonoBehaviour {
    int iDPregunta;
    Nivel nivel;
    string descripcion;
    string puntos;

    public Pregunta() { }
    public Pregunta(int iDPregunta, Nivel nivel, string descripcion, string puntos)
    {
        this.iDPregunta = iDPregunta;
        this.nivel = nivel;
        this.descripcion = descripcion;
        this.puntos = puntos;
    }

    public int IDPregunta
    {
        get
        {
            return iDPregunta;
        }

        set
        {
            iDPregunta = value;
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

    public string Puntos
    {
        get
        {
            return puntos;
        }

        set
        {
            puntos = value;
        }
    }
}
