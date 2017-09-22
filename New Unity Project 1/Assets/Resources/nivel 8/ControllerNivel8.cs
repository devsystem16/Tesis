using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
public class ControllerNivel8 : MonoBehaviour {



	public CargarPreguntaImagenes cargarPreguntaImagenes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private bool getRespuesta( GameObject  opcionesRespuestas, List<Imagen> imgRespuesta) {

		for (int i = 0; i < imgRespuesta.Count; i++) {


			string adta = opcionesRespuestas.GetComponent<GUIText> ().text;

			if (imgRespuesta [i].IdImagen.ToString ().Equals (opcionesRespuestas.GetComponent<GUIText> ().text)) {
				if (imgRespuesta [i].Correcta == 1 && opcionesRespuestas.GetComponent<Renderer> ().material.color ==  Controlaador.colorSeleccion
					||  imgRespuesta [i].Correcta ==  0  &&  opcionesRespuestas.GetComponent<Renderer> ().material.color != Controlaador.colorSeleccion)
				{
					return true;
				}
			}
		}
		return false;
	}


	double porcentaje =0;
	void OnMouseDown () {
	

		if (Input.GetMouseButton (0)) {
			GameObject objClick = gameObject;

			switch (objClick.name) {

			case "btnOk":
				if (cargarPreguntaImagenes.pivotePregunta < cargarPreguntaImagenes.preguntas.Count) {
					int contestadasBien = 0;

					// obtener resultados de la actual contestación.

					int j = 0;
					for (int i = 0; i < cargarPreguntaImagenes.opcionesPreguntas.Count; i++) {

						 
						for (int x = 0; x < cargarPreguntaImagenes.opcionesRespuestas.Count / 3; x++) {


							if (getRespuesta (cargarPreguntaImagenes.opcionesRespuestas [j],
								cargarPreguntaImagenes.preguntas [cargarPreguntaImagenes.pivotePregunta].ImagenesPregunta [i].Imagenes)) {
								contestadasBien++;
							}

							j++;
						}
							 
 

					}


					porcentaje += contestadasBien * 100 / cargarPreguntaImagenes.opcionesRespuestas.Count;
					cargarPreguntaImagenes.pivotePregunta++;

					Debug.Log("porcentaje :" + porcentaje.ToString());

					if (cargarPreguntaImagenes.pivotePregunta < cargarPreguntaImagenes.preguntas.Count) {
						cargarPreguntaImagenes.asignarRespuestasAopcioens ();
					
					}
					 

				
				}
				break;


			default:
				break;
			}

		
		
		}
	
	}
}
