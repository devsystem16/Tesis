using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenRespuesta : Pregunta {

    int iDIMagenRespuesta;
  
    string ruta;
    string descripcion;
    int correcta;

    public ImagenRespuesta() { }
    public ImagenRespuesta(int iDIMagenRespuesta,  string ruta, string descripcion, int correcta)
    {
        this.iDIMagenRespuesta = iDIMagenRespuesta;
        
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

    public string DescripcionR
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
