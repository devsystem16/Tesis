using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
public class InitMenuPersonaje : MonoBehaviour {



 
	 private List<Partida> partidas ;
	// Use this for initialization
	void Start () {
		
	}

 
	 	public   List<Partida>  getPartidas  () {
	 	return partidas;
	 }
  
	void Awake (){
		
		GameObject  [] personajesDisponibles  = new GameObject [3];
		personajesDisponibles [0] = GameObject.Find ("jugador0");
		personajesDisponibles [1] = GameObject.Find ("jugador1");
		personajesDisponibles [2] = GameObject.Find ("jugador2");
		Texture texturaAddJugador = Resources.Load<Texture> ("jugadores/addJugador");

	 
		partidas= Listados.cargarPartidas ();
		for (int i = 0; i < personajesDisponibles.Length; i++) {
			if (i >= partidas.Count) {
				
				personajesDisponibles [i].GetComponent<Renderer> ().material.mainTexture = texturaAddJugador;
			
			} else {
				
				personajesDisponibles [i].GetComponent<Renderer> ().material.mainTexture = Resources.Load<Texture> (partidas [i].Ruta/* .Usuario.Ruta*/); 

			}
		}
	}
	 




}
