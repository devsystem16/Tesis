using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using UnityEngine.SceneManagement; 
public class init1_info : MonoBehaviour {

    void Awake() {

        Usuario usuario = new Usuario();
        usuario.IdUsuario = int.Parse(GameObject.Find("jugador").GetComponent<GUIText>().text);
        usuario.cargar();
   

        Escena escena = new Escena();
        escena.cargar(SceneManager.GetActiveScene().name);

        Partida partida = new Partida();
        partida.cargarPartida(usuario.IdUsuario);

        DetallePartida.guardar(partida.IdPartida, escena.IDEscena, 0);


       

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
