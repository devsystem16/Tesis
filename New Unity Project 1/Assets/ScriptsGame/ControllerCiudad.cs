using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class ControllerCiudad : MonoBehaviour {




	public TextMesh problema ;

	// Muestra de mensajes
	public GameObject flowChart;
	public GameObject sayDialog;
	public Say mensaje;
	public GameObject storyText;
	public GameObject imagenCorrecto ;
	public GameObject imagenincorrecto ;
	public GameObject imagenSiguiente ;


	public Text txtInstruccion;
	public Text txtPergamino;
	public Text txtALgoritmo;
	public  int indicePregunta=0;
	public  int indiceTarea=0;



	public GameObject iteracionesArealizar;
	public GameObject interacionesFijadas ;
	public MoveAtoB moveAtoB ;


	public GameObject accion  ;

	List<string> tareas = new List<string> ();
	List<string> preguntasMensaje  = new List<string>  ();

	void Awake (){


		float interaciones = Random.Range (4, 7);

		Debug.Log (interaciones.ToString ());

		tareas.Add ("Tarea: programa el bus para recorrer "+interaciones.ToString()+" veces la pista respetando las señales de los semáforos.");

		preguntasMensaje.Add ("1.- ¿Cuál es la acción adecuada a realizar para determinar la cantidad de iteraciones indicada?");
		preguntasMensaje.Add ("2.- ¿Qué acción usaría al encontrarse con un semáforo?");

		iteracionesArealizar.GetComponent<TextMesh> ().text = interaciones.ToString ();

		txtInstruccion.text = tareas [indiceTarea];
		txtPergamino.text = preguntasMensaje [indicePregunta];
		txtALgoritmo.text = "";


	}
	// Use this for initialization
	void Start () {
		//PrintMensaje ("correcto", "hola");
	}
	
	// Update is called once per frame
	void Update () {


		string acc = accion.GetComponent<TextMesh> ().text;

		if (accion.GetComponent<TextMesh> ().text.Equals ("validarIteraciones")) {
		

			if (interacionesFijadas.GetComponent<TextMesh> ().text.Equals (iteracionesArealizar.GetComponent<TextMesh> ().text)) {
		
				PrintMensaje ("correcto", "Muy bien, fijaste correctamente la cantidad de iteraciones para cumplir la tarea.");
				//moveAtoB.setStatusGame ("run");
				problema.text = "pr2";

				txtALgoritmo.text = "Repetir desde 1 hasta " + iteracionesArealizar.GetComponent<TextMesh> ().text.ToString() + "\r\n\r\nFin Repetir hasta" ; 


			}
		}


	}


	public void PrintMensaje (string tipo, string mensajePantalla ){


		switch (tipo) {

		case "correcto":
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenCorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (1));
			break;

		case "error": 
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenincorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (0));
			break;

		case "fin":
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenSiguiente.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (2));
			break;

		default:
			break;
		}
	}

	IEnumerator mostrarMensaje (int escorrecto){ 

		switch (escorrecto) {

		case  0:
			yield return new WaitForSeconds (6f);
			imagenincorrecto.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);

			break;


		case 1: 
			yield return new WaitForSeconds (3f);
			imagenCorrecto.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
			accion.GetComponent<TextMesh> ().text = "";
		 	indicePregunta++;

			if (indicePregunta < preguntasMensaje.Count) {

				txtPergamino.text = preguntasMensaje [indicePregunta];
			} else {
			/*	yield return new WaitForSeconds (0f);
				storyText.GetComponent<Text> ().text = "Pasaremos al siguiente nivel.";
				mensaje.SetStandardText ("Pasaremos al siguiente nivel.");
				imagenSiguiente.SetActive (true);
				flowChart.SetActive (true);
				sayDialog.SetActive (true);*/
			} 

			break;


		case 2: 
			yield return new WaitForSeconds (3f);
			imagenSiguiente.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);

			break;


		default:
			break;
		}


	}


}
