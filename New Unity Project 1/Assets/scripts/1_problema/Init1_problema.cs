using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Init1_problema : MonoBehaviour {

 
   public List<GameObject> opcionesRespuestas;
   public   List<Pregunta> preguntas;
   public int pivotePregunta = 1;




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

    public void mostrarPivote() {
        Debug.Log(pivotePregunta);
    }
    public Text t;
    public   void asignarRespuestasAopcioens() {
        if (t != null)
             t.text = preguntas[pivotePregunta].Descripcion;

        for (int i = 0; i < opcionesRespuestas.Count; i++)
        {
            // color normal.
            opcionesRespuestas[i].GetComponent<Renderer>().material.color = new Color(1.000f, 1.000f, 1.000f, 1.000f);

            opcionesRespuestas[i].GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(preguntas[pivotePregunta].ImagenRespuesta[i].Ruta);
            opcionesRespuestas[i].GetComponent<GUIText>().text = preguntas[pivotePregunta].ImagenRespuesta[i].IDIMagenRespuesta.ToString();
        }
    }

 
    void Start () {
        // obtener el usuario que inicio la partida.
 
        Usuario usuario = new Usuario();
        usuario.IdUsuario =  int.Parse( GameObject.Find("jugador").GetComponent<GUIText>().text);
        usuario.cargar();
       
       
        preguntas = Listados.cargarPreguntas(GameObject.Find("nivel").GetComponent<GUIText>().text);
 
        asignarRespuestasAopcioens();




    }
 

    void OnMouseDown() {
        if (Input.GetMouseButton(0)) {


        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
