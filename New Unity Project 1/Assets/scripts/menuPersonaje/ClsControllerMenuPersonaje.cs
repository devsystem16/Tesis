using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using  Assets.scripts.Entidades;
public class ClsControllerMenuPersonaje : MonoBehaviour {


	public List<GameObject> opcionesRespuestas;
	public InitMenuPersonaje initMenuPersonaje;



	private  void redirecting (string seleccion ,List<Partida> partidas ){
		bool existe=false;
		for (int i = 0; i < partidas.Count; i++) {
			if (seleccion.Equals (partidas [i].Usuario.Descripcion)) {
				existe = true;
				break;
			}
		}
		if (existe)
			SceneManager.LoadScene ("1_info");
		else 
			SceneManager.LoadScene ("menuNuevoPersonaje");
	}
	void OnMouseDown ()
	{
 



		if (Input.GetMouseButton (0)) {
			GameObject obj = gameObject;
			List<Partida> partidas =	Listados.cargarPartidas ();
			redirecting (obj.name, partidas);

			/*
			switch (obj.name) {
			case "jugador0": 
		 
				// Material m = obj.GetComponent<Renderer> ().material;
				SceneManager.LoadScene ("1_info");
				break;
			case "jugador1": 
				SceneManager.LoadScene ("menuNuevoPersonaje");
				break;
			case "jugador2": 
				break;

			}
			*/

		}





	}
}
