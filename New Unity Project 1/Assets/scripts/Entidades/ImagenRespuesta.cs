using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenRespuesta : MonoBehaviour {

    int iDIMagenRespuesta;
    Pregunta pregunta;
    string ruta;
    string descripcion;
    int correcta;

    public ImagenRespuesta() { }
    public ImagenRespuesta(int iDIMagenRespuesta, Pregunta pregunta, string ruta, string descripcion, int correcta)
    {
        this.iDIMagenRespuesta = iDIMagenRespuesta;
        this.pregunta = pregunta;
        this.ruta = ruta;
        this.descripcion = descripcion;
        this.correcta = correcta;
    }

    public int IDIMagenRespuesta
    {
        get
        {
            return iDIMagenRespuesta;
        }

        set
        {
            iDIMagenRespuesta = value;
        }
    }

    public Pregunta Pregunta
    {
        get
        {
            return pregunta;
        }

        set
        {
            pregunta = value;
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

    public int Correcta
    {
        get
        {
            return correcta;
        }

        set
        {
            correcta = value;
        }
    }
}
