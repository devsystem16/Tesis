using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class ClsMostrarMensajes : MonoBehaviour {





	// Muestra de mensajes
	public GameObject flowChart;
	public GameObject sayDialog;
	public Say mensaje;
	public GameObject storyText;

	public GameObject imagenCorrecto ;
	public GameObject imagenincorrecto ;
	public GameObject imagenSiguiente ;
	// end


 

	public void PrintMensaje (string tipo, string mensajePantalla  , float tiempo){


		switch (tipo) {

		case "correcto":
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			 
			flowChart.SetActive (true);
			imagenCorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (1,tiempo));
			break;

		case "error": 
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenincorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (0,tiempo));
			break;

		case "fin":
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenSiguiente.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (2,tiempo));
			break;

		default:
			break;
		}
	}

	IEnumerator mostrarMensaje (int escorrecto, float tiempo){ 

		switch (escorrecto) {

		case  0:
			yield return new WaitForSeconds (tiempo);
			imagenincorrecto.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
			break;

				
		case 1: 
			yield return new WaitForSeconds (tiempo);
			imagenCorrecto.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
  			break;


		case 2: 
			yield return new WaitForSeconds (tiempo);
			imagenSiguiente.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
			break;

		default:
			break;
		}


	}


}
