using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickIf : MonoBehaviour {


	public string paso  ;
	// Use this for initialization

	public  GameObject paso1if; 
	public  GameObject paso2if; 
	public  GameObject paso3if; 
	public  GameObject paso4if; 


	public GameObject canvasPreguntaUsuario;
	public GameObject camaraBus ;
	public GameObject menuSemaforo ;



	public TextMesh pasoIf;

	public Text txtAlgoritmo;
	public  GameObject numeroInteraciones;

	public ClsMostrarMensajes clsMostrarMensajes ;



	public List<GameObject> listaOcultarObjetos;
	public MoveAtoB moveAtoB ;
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator interaccion(string cual , float tiempo){  

		if (cual.Equals ("finCicloFor")) {
			yield return new WaitForSeconds (tiempo);
			for (int i = 0; i < listaOcultarObjetos.Count; i++) {
				listaOcultarObjetos [i].SetActive (false);
			}

			paso4if.SetActive (false);

			menuSemaforo.SetActive (false);
			paso4if.SetActive (false);
			canvasPreguntaUsuario.SetActive (true);
			camaraBus.SetActive (true);
			moveAtoB.setStatusGame ("run");
		}
	}



	void OnMouseDown(){
	

	 


		if (Input.GetMouseButton (0)) {
		

			GameObject opcionSeleccionada = gameObject;

			if (pasoIf.text.Equals ("paso1")) {
				
				if (opcionSeleccionada.name.Equals ("LuzSemaforo")) {
					paso1if.SetActive (false);
					paso2if.SetActive (true);

					pasoIf.text = "paso2";
				} else {
					Debug.Log ("Te has equivocado");
				}
 
			}else  if (pasoIf.text.Equals ("paso2")) {
				if (opcionSeleccionada.name.Equals ("comparar")) {
					paso2if.SetActive (false);
					paso3if.SetActive (true);
					pasoIf.text = "paso3";
				}else {
					Debug.Log ("Te has equivocado");
				}
			} else if (pasoIf.text.Equals ("paso3")) {
				if (opcionSeleccionada.name.Equals ("rojo")) {
					paso3if.SetActive (false);
					paso4if.SetActive (true);
					pasoIf.text = "paso4";
				}else {
					Debug.Log ("Te has equivocado");
				}
			} else if (pasoIf.text.Equals ("paso4")) {
				if (opcionSeleccionada.name.Equals ("detenerBus")) {


				 
					txtAlgoritmo.text  = "Repetir desde 1 hasta " + numeroInteraciones.GetComponent<TextMesh> ().text.ToString() + "\r\n\r\n" +
						"     Condición si (Semáforo está en rojo) Entonces\r\n          Detener bus\r\n     Fin condición\r\n\r\nFin Repetir hasta" ; 

			

					clsMostrarMensajes.PrintMensaje ("fin", "Muy bien, ha culminado correctamente la tarea.", 4F);
					StartCoroutine (interaccion ("finCicloFor", 4f));


					 
 
				}
			}
		





		}
	
	}
}
