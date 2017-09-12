using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiencia : MonoBehaviour {

	private int iDExperiencia ;
	private string descripcion ;
	string ruta;

	public Experiencia (){}

	public Experiencia (int iDExpericia , string descripcion , string ruta)
	{
		this.iDExperiencia = iDExpericia;
		this.descripcion = descripcion;
		this.ruta = ruta;
	}

	public int IDExperiencia {

		get { return this.iDExperiencia;}
		set { this.iDExperiencia = value;}
	}
	public string Descripcion {

		get { return this.descripcion;}
		set { this.descripcion = value;}
	}
	public string Ruta {

		get { return this.ruta;}
		set { this.ruta = value;}
	}
}
