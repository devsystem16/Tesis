using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class MecanicaController : MonoBehaviour {



    public List<GameObject> ilustraciones;

	public GameObject Estadocorrecto;
	public GameObject Estadoincorrecto; 



	public Text txtInstruccion;
	public Text txtPergamino;
	public Text txtALgoritmo;
	public  int indicePregunta=0;

	 
	// Muestra de mensajes
	public GameObject flowChart;
	public GameObject sayDialog;
	public Say mensaje;
	public GameObject storyText;

	public GameObject imagenCorrecto ;
	public GameObject imagenincorrecto ;
	public GameObject imagenSiguiente ;
	// end



	private List<string> preguntas = new List<string> ();
	 

	// Use this for initialization
	void Start () {
		preguntas = new List<string> ();
		preguntas.Add ("Para cambiar el neumático necesitarás ayuda de alguien, dentro de la escena. selecciona quién te puede ayudar.");
		preguntas.Add ("Muy bien, ahora que " +Constantes.nombreConductor+" ayudará sosteniendo un neumático. ¿Qué neumático sostendrá? Asígnale uno. \r\n\r\n ¿para asignar se utilizar?"   );
		preguntas.Add ("Correcto, ahora ¿Qué asignarás  a "+ Constantes.nombreConductor+" ?"   );
		preguntas.Add ( "Para la siguiente asignación, ¿cuál sería la variable correcta?  \r\nTouch sobre ella.");
		preguntas.Add ("Para continuar, debes asignar. ¿Qué operador es útil.?");

		preguntas.Add ("¿Qué se le asignara a la variable?");

		preguntas.Add ("Para terminar el intercambio de neumáticos, ¿cuál sería la asignación final? \r\n Selecciona la variable con un Touch.");

		preguntas.Add ("hay que asignar. ¿Qué operador es útil.?");

		preguntas.Add ("¿Qué le asignaremos a la variable.");



		txtPergamino.text = preguntas [indicePregunta].ToString();

	}

	private string modo ="" ;
	public  void validarRespuesta (string objetoSeleccionado ){

		switch (indicePregunta) {

		case 0:
			if (objetoSeleccionado.Equals ("niño")) {
				PrintMensaje ("correcto", "Muy bien " + Constantes.nombreConductor + " ayudará sosteniendo un neumático. ¿Asígnale el neumático que deba sostener?");
				txtALgoritmo.text = Constantes.nombreConductor.ToUpper ().ToString () + " ";


			} else if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", "Incorrecto, El autobus es el objeto que tiene el neumàtico dañado, selecciona el  objeto correcto.");
			
			} else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error", "Incorrecto, La mesa solo soporta 1 neumàtico.");
			}
			
			break;

		case 1: 

			if (objetoSeleccionado.Equals ("igual")) {
				PrintMensaje ("correcto", "Muy bien,  seleccionaste muy bien el operador de asignación '=' ");
				txtALgoritmo.text += " = ";

			} else if (objetoSeleccionado.Equals ("niño")) {
				PrintMensaje ("error", "Incorrecto, " + Constantes.nombreConductor + " no es un operador.");

			}  else if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", "Incorrecto, el autobus no es un operador.");


			} else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error", "Incorrecto, el neumático no es un operador.");
			}

			break;

		case 2: 

			if (objetoSeleccionado.Equals ("niño")) {
				PrintMensaje ("error", "Incorrecto, " + Constantes.nombreConductor + " no es un neumàtico.");

			} else if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("correcto", "Muy bien, por ahora " + Constantes.nombreConductor + " tendrá la neumàtico averiada del autobus.");
				txtALgoritmo.text += " Neumático autobus";
				modo = "1";

			} else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("correcto", "Muy bien, por ahora " + Constantes.nombreConductor + " tendrá el neumàtico de respuesto de la mesa.");
				txtALgoritmo.text += " Neumático mesa";
				modo = "2";
			}
			break;

		case 3: 

			// en caso de que la asignacion de la siguiente sentencia deba de ser. Bus =
			if (modo.Equals ("1")) {
				if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("correcto", "Muy bien, por ahora " + Constantes.nombreConductor + " tendrá el neumàtico de respuesto de la mesa.");
					txtALgoritmo.text += "\r\n Neumático autobus";
				 
				} else {
					PrintMensaje ("error", "Error");
				}
			} 
			// en caso de que la asignacion de la siguiente sentencia deba de ser. llantaMesa =
			else if (modo.Equals ("2")) {
				if (objetoSeleccionado.Equals ("llanta")) {
					PrintMensaje ("correcto", "Muy bien, por ahora " + Constantes.nombreConductor + " tendrá el neumàtico de respuesto de la mesa.");
					txtALgoritmo.text += "\r\n Neumático repuesto";
				} else {
					PrintMensaje ("error", "Error");
				}

			}
			break;

		// Para continuar, debes asignar. ¿Qué operador es útil.?
		case 4:
			if (objetoSeleccionado.Equals ("igual")) {
				PrintMensaje ("correcto", "Muy bien,  seleccionaste muy bien el operador de asignación '=' ");
				txtALgoritmo.text += " = ";

			} else if (objetoSeleccionado.Equals ("niño")) {
				PrintMensaje ("error", "Incorrecto, "+Constantes.nombreConductor+" no es un operador.");

			} else if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", "Incorrecto, el autobus no es un operador.");


			} else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error", "Incorrecto, el neumático no es un operador.");
			}

			break;




			 // ¿Qué se le asignara a la variable?
		case 5:
			if (modo.Equals ("1")) {

				if (objetoSeleccionado.Equals ("llanta")) { 
					PrintMensaje ("correcto", "Muy bien, has seleccionado correctamente. ");
					txtALgoritmo.text += "Neumático repuesto"; 

				} else if (objetoSeleccionado.Equals ("niño")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else {
					PrintMensaje ("error", "Incorrecto, no es necesario otro operador.");
				}


			} else if (modo.Equals ("2")) {
			
				if (objetoSeleccionado.Equals ("llanta")) { 
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("niño")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("correcto", "Muy bien, has seleccionado correctamente. "); 
					txtALgoritmo.text += "Neumático autobus"; 
				} else {
					PrintMensaje ("error", "Incorrecto, no es necesario otro operador.");
				}

			}
			break;





			// Para terminar el intercambio de neumáticos, ¿cuál sería la asignación final?  Selecciona la variable con un Touch.
		case 6:
			if (modo.Equals ("1")) {

				if (objetoSeleccionado.Equals ("llanta")) { 
					PrintMensaje ("correcto", "Muy bien, has seleccionado correctamente. ");
					txtALgoritmo.text += "\r\nNeumático repuesto"; 

				} else if (objetoSeleccionado.Equals ("niño")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else {
					PrintMensaje ("error", "Incorrecto, no es necesario otro operador.");
				}


			} else if (modo.Equals ("2")) {

				if (objetoSeleccionado.Equals ("llanta")) { 
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("niño")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");

				} else if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("correcto", "Muy bien, has seleccionado correctamente. "); 
					txtALgoritmo.text += "\r\nNeumático autobus"; 
				} else {
					PrintMensaje ("error", "Incorrecto, no es necesario otro operador.");
				}

			}
			break;


		case 7: 

			if (objetoSeleccionado.Equals ("igual")) {
				PrintMensaje ("correcto", "Muy bien, para asignar se utilizar operador '=' ");
				txtALgoritmo.text += " = ";

			} else if (objetoSeleccionado.Equals ("niño")) {
				PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");
			} else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");
			} else if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");
			} else {
				PrintMensaje ("error", " ¿Estás seguro?, al parecer has cometido algún error.");

			}


			break; 

			// ¿Que le asignaremos a la variable.?
		case 8:
				if (objetoSeleccionado.Equals ("llanta")) { 
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");
				} else if (objetoSeleccionado.Equals ("niño")) {
					PrintMensaje ("correcto", "Muy bien, has seleccionado correctamente. ");
					txtALgoritmo.text += " El que tiene " + Constantes.nombreConductor.ToUpper (); 
				} else if (objetoSeleccionado.Equals ("bus")) {
					PrintMensaje ("error", " ¿Estás seguro?, Piénsalo bien eh intentalo nuevamente.");
				} else {
					PrintMensaje ("error", "Incorrecto, no es necesario otro operador.");
				}

			 
			break;



		default:
			break;
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

			indicePregunta++;

			if (indicePregunta < preguntas.Count) {

				txtPergamino.text = preguntas [indicePregunta];
			} else {
				yield return new WaitForSeconds (0f);
				storyText.GetComponent<Text> ().text = "Pasaremos al siguiente nivel.";
				mensaje.SetStandardText ("Pasaremos al siguiente nivel.");
				imagenSiguiente.SetActive (true);
				flowChart.SetActive (true);
				sayDialog.SetActive (true);
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


















	// Update is called once per frame
	void Update () {
		
	}


    public void asignarImagen(object[] parametros  )
    {
        string rutaImagen = parametros[0].ToString();
        string numeroBus = parametros[1].ToString();

	 
		 
        for (int i = 0; i < ilustraciones.Count; i++)
        {
            GameObject oIlustracion = ilustraciones[i];

            // Verificar si esta activa.
			if (oIlustracion.activeInHierarchy == false)
            {
                oIlustracion.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
                oIlustracion.SetActive(true);
				oIlustracion.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\")+1);


				if (i == (ilustraciones.Count - 1)) {
					// validar respuesta.
					validarResultado (ilustraciones);
				
					break;

				} else {
					break;
				}
             

            } // End if 

		

        } // End For

	 
 
    } // End  void.

	void validarResultado( List<GameObject> expresion) {

		if (Constantes.concatenar (expresion).Equals ("niño,igual,bus,bus,igual,llanta,llanta,igual,niño")
		
			||  Constantes.concatenar (expresion).Equals ("niño,igual,llanta,llanta,igual,bus,bus,igual,niño")
		) {
			Estadocorrecto.SetActive (true);

			 
		} else {
			Estadoincorrecto.SetActive(true);
			StartCoroutine (Incorrecto ());

	 
		}
		Debug.Log ("Validar");
    }


	IEnumerator Incorrecto (){
	
		yield return new WaitForSeconds (3f);
		for (int i = 0; i < ilustraciones.Count; i++) {
			ilustraciones [i].SetActive (false);
		}

		Estadoincorrecto.SetActive(false);
	}

}
