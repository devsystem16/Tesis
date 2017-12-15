using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class EstacionamientoController : MonoBehaviour {



    public GameObject ilustracionExpresion1;
    public GameObject ilustracionExpresion2;
    public GameObject ilustracionExpresion3;




    public GameObject Estadocorrecto;
    public GameObject Estadoincorrecto;

	public Animator animator ;

	public AudioClip sonidoAutobus ;
	private AudioSource audioPlayer ;


	public GameObject flowChart;
	public Say mensaje;

	public GameObject imagenCorrecto ;
	public GameObject imagenincorrecto ;
	public GameObject imagenSiguiente ;


 

	public GameObject storyText;

    // Use this for initialization
    private List<string>    listaNumeroBuses;
    private int pivot =0;
	public GameObject  sayDialog ;




	public Text txtInstruccion;
	public Text txtPergamino ;
	public Text txtAlgoritmo ;
 
	private int indicePregunta =0 ;
	private  List<string> preguntas = new List<string> () ;

    void Awake() {
        listaNumeroBuses = new List<string>();

        for (int i = 0; i < 3; i++)
        {
            string dato = (Mathf.Round(Random.Range(1f, 30f))).ToString();
            if (!listaNumeroBuses.Contains(dato)) {
                listaNumeroBuses.Add(dato);
            }
        }


 

		  
		txtAlgoritmo.text = "";

    } 
    void Start()
    {


        GameObject numeroBus1 = GameObject.Find("numeroBus1"); numeroBus1.GetComponent<TextMesh>().text = listaNumeroBuses[0];
        GameObject numeroBus2 = GameObject.Find("numeroBus2"); numeroBus2.GetComponent<TextMesh>().text = listaNumeroBuses[1];
        GameObject numeroBus3 = GameObject.Find("numeroBus3"); numeroBus3.GetComponent<TextMesh>().text = listaNumeroBuses[2];

        pivot = int.Parse(Mathf.Round(Random.Range(0f, 2f)).ToString());

		txtInstruccion.text = "Asignar bus " + listaNumeroBuses [pivot].ToString() ;
		preguntas = new List<string> ();
 
		preguntas.Add ("Para realizar la asignación del bus " +listaNumeroBuses[pivot].ToString() + "  a "+Constantes.nombreConductor.ToString()+". ¿Quién sería la variable? da un Touch sobre ella.");
		preguntas.Add ("¿Con Qué operador se realiza la asignación?");
		preguntas.Add ("¿Que se le asignará a  "+Constantes.nombreConductor+"?");

		txtPergamino.text =preguntas[indicePregunta].ToString();

    }
	
	// Update is called once per frame
	void Update () {

    }
 



	public  void validarRespuesta (object[] parametros  ){
		
	 
		string objetoSeleccionado = parametros [0].ToString();
		string numeroBus = parametros [1].ToString();

		switch (indicePregunta) {

		case 0: 
			if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", "Incorrecto, Se necesita que se le asigne un bus a Jaime, de ésta manera asignarás un bus a otro bus.");

			}  else if (objetoSeleccionado.Equals ("persona")) {
				PrintMensaje ("correcto", "Muy bien, has seleccionado la opción correcta.");

				txtAlgoritmo.text += "JAIME";
			}
			else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error", "Incorrecto, la llanta no es la variable correcta.");
			}
			break;

		case 1: 
			if (objetoSeleccionado.Equals ("bus")) {
				PrintMensaje ("error", "Incorrecto, para realizar una asignación debes usar un operador aritmético.");

			}  else if (objetoSeleccionado.Equals ("persona")) {
				PrintMensaje ("error", "Incorrecto, Jaime es la variable.");
			}
			else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error",  "Incorrecto, para realizar una asignación debes usar un operador aritmético.");
			}
			else if (objetoSeleccionado.Equals ("igual")) {
				PrintMensaje ("correcto",  "Correcto, Muy bien con el operador de asignacion '=' se realiza la asignación.");
				txtAlgoritmo.text += " = ";
			}
			else  {
				PrintMensaje ("error",  "Si debes seleccionar un operador, pero éste no es el correcto.");
			}


			break;

		case 2: 


			if (objetoSeleccionado.Equals ("bus") && numeroBus.Equals(listaNumeroBuses[pivot].ToString())) {
				txtAlgoritmo.text += " Bus " + listaNumeroBuses[pivot].ToString();
				PrintMensaje ("correcto", "Correcto, has asignado el bus correcto a Jaime.");
	


			}  else if (objetoSeleccionado.Equals ("bus") && !numeroBus.Equals(listaNumeroBuses[pivot].ToString())) {
				PrintMensaje ("error", "Incorrecto, Si se debe de asignarle el bus pero te equivocaste con el número.");
			} 

			else if (objetoSeleccionado.Equals ("persona")) {
				PrintMensaje ("error", "Incorrecto, Jaime es la variable.");
			}
			else if (objetoSeleccionado.Equals ("llanta")) {
				PrintMensaje ("error",  "Incorrecto, la tarea no es asignarle una llanata a Jaime para que trabaje.");
			}
			else  {
				PrintMensaje ("error",  "Incorrecto, No es necesario usar otro operador.");
			}
			break;

		default:
			break;
		}

	 
	}

	public void PrintMensaje (string tipo, string mensajePantalla ){

		if (tipo.Equals ("error")) {
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenincorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (0));

		} else if (tipo.Equals ("correcto")) {
			
			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenCorrecto.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (1));


		} else if (tipo.Equals ("fin")) {

			storyText.GetComponent<Text> ().text = mensajePantalla;
			mensaje.SetStandardText (mensajePantalla);
			flowChart.SetActive (true);
			imagenSiguiente.SetActive (true);
			sayDialog.SetActive (true);
			StartCoroutine (mostrarMensaje (2));

		}

	}
	IEnumerator mostrarMensaje (int escorrecto){
 
	
		if (escorrecto == 1) {
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


 
		
		} else if (escorrecto == 0 ){
			yield return new WaitForSeconds (6f);
			imagenincorrecto.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
		}
		else if (escorrecto == 2 ){
			yield return new WaitForSeconds (3f);
			imagenSiguiente.SetActive (false);
			flowChart.SetActive (false);
			sayDialog.SetActive (false);
		}


	} 












    public void asignarImagen(object[] parametros /*string rutaImagen, string numeroBus*/) {


        string rutaImagen = parametros[0].ToString();
        string numeroBus = parametros[1].ToString();

        if (!ilustracionExpresion1.activeInHierarchy)
        {
            ilustracionExpresion1.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion1.SetActive(true);

            ilustracionExpresion1.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\")+1)+ numeroBus;

        }
        else if (!ilustracionExpresion2.activeInHierarchy)
        {
            ilustracionExpresion2.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion2.SetActive(true);
            ilustracionExpresion2.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\") + 1) + numeroBus;

        }
        else {
            ilustracionExpresion3.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion3.SetActive(true);
            ilustracionExpresion3.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\") + 1) + numeroBus;
 
            List<GameObject> exprecion = new List<GameObject>();
            exprecion.Add(ilustracionExpresion1);
            exprecion.Add(ilustracionExpresion2);
            exprecion.Add(ilustracionExpresion3);


            string bs = "bus" + listaNumeroBuses[pivot];
            if (Constantes.concatenar(exprecion).Equals("jaime,igual," + bs))
            {

                Estadocorrecto.SetActive(true);
            }
            else {
				animator.Play ("operacionIncorrecta");
                Estadoincorrecto.SetActive(true);
                StartCoroutine(incorrecto());
            }
 

        }
    }


    IEnumerator incorrecto() {
        yield return new WaitForSeconds(5f);

        Estadoincorrecto.SetActive(false);
        ilustracionExpresion1.SetActive(false);
        ilustracionExpresion2.SetActive(false);
        ilustracionExpresion3.SetActive(false);
		animator.Play ("idle");


    }

}
