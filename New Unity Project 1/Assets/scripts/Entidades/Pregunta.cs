using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using Assets.scripts.Entidades;
public class Pregunta : MonoBehaviour {
    int iDPregunta;
    Nivel nivel;
    string descripcion;
    string puntos;
    List<ImagenRespuesta> imagenRespuesta;
    List<ImagenPregunta> imagenesPregunta;

    public Pregunta() { }
    public Pregunta(int iDPregunta, Nivel nivel, string descripcion, string puntos)
    {
        this.iDPregunta = iDPregunta;
        this.nivel = nivel;
        this.descripcion = descripcion;
        this.puntos = puntos;
    }
    public void cargarRespuestas()
    {

        imagenRespuesta = new List<ImagenRespuesta>();

        MyDBConnection oCnn = new MyDBConnection();
        oCnn.conectar();
        IDataReader odr = oCnn.select(ControllerSQL.pregunta_listarRespuestas(this.iDPregunta.ToString()));
        while (odr.Read())
        {
            ImagenRespuesta unaImagenRespuesta = new ImagenRespuesta();
            unaImagenRespuesta.IDIMagenRespuesta = odr.GetInt16(0);
            unaImagenRespuesta.IDPregunta = odr.GetInt16(1);
            unaImagenRespuesta.Ruta = odr.GetString(2);
            unaImagenRespuesta.Descripcion = odr.GetString(3);
            unaImagenRespuesta.Correcta = odr.GetInt32(4);
            imagenRespuesta.Add(unaImagenRespuesta);

        }
        if (odr != null)
        {
            if (!odr.IsClosed)
                odr.Close();
        }
        oCnn.cerrar();



        


    }



    public void cargarImagenPregunta()
    {

        this.imagenesPregunta = new List<ImagenPregunta>();

        MyDBConnection oCnn = new MyDBConnection();
        oCnn.conectar();
        IDataReader odr = oCnn.select(ControllerSQL.pregunta_listarImagenPregunta(this.iDPregunta.ToString()));
        while (odr.Read())
        {
            ImagenPregunta unaImagenPregunta= new ImagenPregunta();
            unaImagenPregunta.IdImagenPregunta = odr.GetInt32(0);
            unaImagenPregunta.RutaImagenPregunta = odr.GetString(1);
            unaImagenPregunta.DescripcionImagenPregunta = odr.GetString(2);
            unaImagenPregunta.iDPregunta = odr.GetInt32(3);
            imagenesPregunta.Add(unaImagenPregunta);

        }
        if (odr != null)
        {
            if (!odr.IsClosed)
                odr.Close();
        }
        oCnn.cerrar();

        for (int i = 0; i < imagenesPregunta.Count; i++)
        {
            imagenesPregunta[i].cargarImagenes();
        }

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

    public List<ImagenRespuesta> ImagenRespuesta
    {
        get
        {
            return imagenRespuesta;
        }

        set
        {
            imagenRespuesta = value;
        }
    }

    internal List<ImagenPregunta> ImagenesPregunta
    {
        get
        {
            return imagenesPregunta;
        }

        set
        {
            imagenesPregunta = value;
        }
    }
}
