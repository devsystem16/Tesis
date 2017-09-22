using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using UnityEngine.UI;
public class CargarPreguntaImagenes : MonoBehaviour {


    public List<GameObject> opcionesRespuestas;
    public List<GameObject> opcionesPreguntas;
    public int pivotePregunta = 0;


    public List<Pregunta> preguntas;
    // Use this for initialization
    void Start () {

        preguntas = Listados.cargarPreguntas(GameObject.Find("nivel").GetComponent<GUIText>().text);
        for (int i = 0; i < preguntas.Count; i++)
        {
            preguntas[i].cargarImagenPregunta();
        }


        asignarRespuestasAopcioens();






    }



	public  Text t;
    public void asignarRespuestasAopcioens()
    {


		t.text = preguntas[pivotePregunta].Descripcion;
		 

		int pivot_objetos = 0;
        for (int i = 0; i < opcionesPreguntas.Count; i++)
        {
          
           // color normal.
            opcionesPreguntas[i].GetComponent<Renderer>().material.color = new Color(1.000f, 1.000f, 1.000f, 1.000f);

            opcionesPreguntas[i].GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(preguntas[pivotePregunta].ImagenesPregunta[i].RutaImagenPregunta);
            opcionesPreguntas[i].GetComponent<GUIText>().text = preguntas[pivotePregunta].ImagenesPregunta[i].IdImagenPregunta.ToString();
           
			for (int j = 0; j < preguntas[pivotePregunta].ImagenesPregunta[i].Imagenes.Count; j++) {
				opcionesRespuestas[pivot_objetos].GetComponent<Renderer>().material.color = new Color(1.000f, 1.000f, 1.000f, 1.000f);


				opcionesRespuestas[pivot_objetos].GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(
					preguntas[pivotePregunta].ImagenesPregunta[i].Imagenes[j].RutaImagen);
				
				opcionesRespuestas[pivot_objetos].GetComponent<GUIText>().text = 
					preguntas[pivotePregunta].ImagenesPregunta[i].Imagenes[j].IdImagen.ToString();
				
				pivot_objetos ++;

			}

        }
    }



        // Update is called once per frame
        void Update () {
		
	}
}
