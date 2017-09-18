using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.scripts.Entidades;
public class ClsGameController : MonoBehaviour {


	 public List<GameObject> opcionesRespuestas;
    //public List<Texture> imagenesParaOpciones;


    public Init1_problema init1_problema;

    private Usuario player;
    // Use this for initialization
    void Start () {
		/*GameObject unObj = opcionesRespuestas [0];
		Texture img = Resources.Load<Texture> ("nivel 1/6");
		unObj.GetComponent<Renderer>().material.mainTexture = img;

*/
	}


 
	// Update is called once per frame
	void Update () {
		 
	 
	}




    private bool getRespuesta(List<GameObject> opcionesRespuestas, ImagenRespuesta imgRespuesta) 
    {
        for (int i = 0; i < opcionesRespuestas.Count; i++)
        {

            string aaa = opcionesRespuestas[i].GetComponent<GUIText>().text;

            if (opcionesRespuestas[i].GetComponent<GUIText>().text == imgRespuesta.IDIMagenRespuesta.ToString()) {


                if (opcionesRespuestas[i].GetComponent<Renderer>().material.color == Color.green &&
                    imgRespuesta.Correcta == 1
                    ||
                    opcionesRespuestas[i].GetComponent<Renderer>().material.color != Color.green &&
                    imgRespuesta.Correcta == 0
                    )
                {
                    return true;

                }
                else
                    return false;



            }
        }
        return false;
    }

    double porcentaje = 0;
    void OnMouseDown ()
	{


		if (Input.GetMouseButton (0)) {
			GameObject objClick = gameObject;

			switch (objClick.name) {

			case "btnOk":
                    // string escenaActua =	SceneManager.GetActiveScene ().name;


                   
                    if (init1_problema.pivotePregunta < init1_problema.preguntas.Count)
                    {
 
                        int contestadasBien = 0;
                        for (int i = 0; i < init1_problema.preguntas[init1_problema.pivotePregunta].ImagenRespuesta.Count; i++)
                        {
                            if (getRespuesta(opcionesRespuestas, init1_problema.preguntas[init1_problema.pivotePregunta].ImagenRespuesta[i]))
                                contestadasBien++;
                        }

                        init1_problema.pivotePregunta += 1;
                        porcentaje += contestadasBien * 100 / opcionesRespuestas.Count;


                        Debug.Log(porcentaje);


                        if (init1_problema.pivotePregunta < init1_problema.preguntas.Count)
                            // segir mostrando preguntas.
                            init1_problema.asignarRespuestasAopcioens();

                        else {
                            //  se terminaron las preguntas.


                            player = new Usuario();

                            player.IdUsuario = int.Parse( GameObject.Find("jugador").GetComponent<GUIText>().text);   player.cargar();

                            Escena escena = new Escena();
                            escena.cargar(SceneManager.GetActiveScene().name);

                            Partida partida = new Partida();
                            partida.cargarPartida(player.IdUsuario);

                            porcentaje = porcentaje / init1_problema.preguntas.Count;
                            DetallePartida.guardar(partida.IdPartida, escena.IDEscena, porcentaje);
 
                            SceneManager.LoadScene(player.nivel("next"));

                        }
                    }
                    else {
                        // Termino de resolver las preguntas.
                        Debug.Log("Termino este nivel.-");
                    }

  
				break;

			}
		}

	}
}
