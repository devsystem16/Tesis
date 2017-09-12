using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour {

	int idNivel ;
	Experiencia experiencia ;
	string descripcion ;
	int orden ;

    public Nivel() { }

    public Nivel(int idNivel, Experiencia experiencia, string descripcion, int orden)
    {
        this.IdNivel = idNivel;
        this.Experiencia = experiencia;
        this.Descripcion = descripcion;
        this.Orden = orden;
    }

    public int IdNivel
    {
        get
        {
            return idNivel;
        }

        set
        {
            idNivel = value;
        }
    }

    public Experiencia Experiencia
    {
        get
        {
            return experiencia;
        }

        set
        {
            experiencia = value;
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
