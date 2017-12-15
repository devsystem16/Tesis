using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour {


	public Material colorRojo;
	public Material colorNaranja;
	public Material colorVerde ;
	public Material colordefault ;


	public GameObject focoRojo;
	public GameObject focoNaranja;
	public GameObject focoVerde;


	public float tiempoRojo;
	public float tiempoNaranja;
	public float tiempoVerde;


	public string inicioColor; 
	private string estadoActual  ;

	private  string ColorSemaforo ="verde";

	public string getStatusSemaforo (){
		return  ColorSemaforo;
	}

	// Use this for initialization
	void Start () {
		estadoActual = inicioColor;
		focoVerde.GetComponent<Renderer> ().material = colorVerde;
	}
	
	// Update is called once per frame
	void Update () {

		if (estadoActual.Equals ("verde")) {
 
			StartCoroutine (cambiarVerde (tiempoVerde));
		}


		else if (estadoActual.Equals ("naranja")) {
	 
			StartCoroutine (cambiarNaranja (tiempoRojo));
		}


		else 	if (estadoActual.Equals ("rojo")) {
 
			StartCoroutine (cambiarRojo (tiempoNaranja));
		}


	 
	}


	IEnumerator cambiarVerde ( float  sg){
		yield return new WaitForSeconds (sg);
		focoVerde.GetComponent<Renderer> ().material = colorVerde;
		focoNaranja.GetComponent<Renderer> ().material = colordefault;
		focoRojo.GetComponent<Renderer> ().material = colordefault;
		estadoActual = "naranja";
		   StopAllCoroutines();
		ColorSemaforo = "verde";
	}

	IEnumerator cambiarNaranja ( float  sg){
		yield return new WaitForSeconds (sg);
		focoVerde.GetComponent<Renderer> ().material = colordefault;
		focoNaranja.GetComponent<Renderer> ().material = colorNaranja;
		focoRojo.GetComponent<Renderer> ().material = colordefault;
		estadoActual = "rojo";
    	StopAllCoroutines();
		ColorSemaforo = "naranja";
	}

	IEnumerator cambiarRojo( float  sg){
		yield return new WaitForSeconds (sg);
		focoVerde.GetComponent<Renderer> ().material = colordefault;
		focoNaranja.GetComponent<Renderer> ().material = colordefault;
		focoRojo.GetComponent<Renderer> ().material = colorRojo;
		estadoActual = "verde";
		StopAllCoroutines();
		ColorSemaforo = "rojo";
	}





}
