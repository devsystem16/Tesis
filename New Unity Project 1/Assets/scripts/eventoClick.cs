using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

using  UnityEngine.SceneManagement ;
public class eventoClick : MonoBehaviour {
	public MyDBConnection oCnn_sqlIt; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void  OnMouseDown () {
	 
 
		if (Input.GetMouseButton (0)) {

		 

			oCnn_sqlIt = new MyDBConnection ();
			oCnn_sqlIt.conectar ();


			//  saber en que nivel estoy
			GameObject objNivel = GameObject.Find ("nivel");
			string nivel = objNivel.GetComponent<Text> ().text;


			switch (nivel) {
 

			case "menuInicio":

				GameObject objInicio = gameObject;
				string btns = objInicio.name;

				if (btns.Equals ("btnIniciar")) {
					SceneManager.LoadScene ("saludo");
				} 
				else if  (btns.Equals ("btnSalir")) {
				
					Debug.Log ("ha salido");
					Application.Quit();
				} 

				break;


			case "1":
 
				GameObject obj = gameObject;
				string btn = obj.name;

				if (btn.Equals ("btnOk")) {
					Debug.Log ("Click en boton ok");
 


					GameObject objgame = GameObject.Find("opcionSeleccionada");
					string respuesta = objgame.GetComponent<Text>().text ;
					if (respuesta.Equals("1")) {
						SceneManager.LoadScene ("level2");
						Debug.Log("Correcto");

					}else {
						Debug.Log("Equivocado");
					}



				} else if (btn.Equals ("btnInformacion")){
					Debug.Log ("Click en informacion");

				}

				else if (btn.Equals ("btnMusica")){
					 

					// Clic en el boton de silencio.
					GameObject objSound = GameObject.Find ("musica");
					bool estado = !objSound.GetComponent<AudioSource> ().mute;
					objSound.GetComponent<AudioSource> ().mute = estado;
					GameObject btnMusica = GameObject.Find ("btnMusica");
					GameObject cuboPresent = GameObject.Find("objImagenes");
					Imagenes clsImagenes =  cuboPresent.GetComponent<Imagenes>();
					btnMusica.GetComponent<Renderer> ().material.mainTexture = clsImagenes.GetImagenes () [  ((estado == true )? 1:0 )];
			 



				}
				else if (btn.Equals ("btnSalir")){
					Debug.Log ("Click en salir");
					SceneManager.LoadScene ("KinectAvatarsDemo");
				}
				break;




			case "2":


				GameObject objs = gameObject;
				string btnss = objs.name;
				if (btnss.Equals ("btnOk")) {
					Debug.Log ("Click en boton ok");
					GameObject okContinue = GameObject.Find("opcionSeleccionada");
					string respuesta2 = okContinue.GetComponent<Text>().text ;
					if (respuesta2.Equals("4")) {
						Debug.Log("Correcto");
						SceneManager.LoadScene ("saludo2");

					}else {
						Debug.Log("Equivocado");
					}
				}




				break;
			case "3":
				break;
			case "4":
				break;
			case "5":
				break;
			case "6":
				break;
			case "7":
				break;
			case "8":
				break;
			case "9":
				break;
			case "10":
				break;




			default:
				break;
			}









		}
	}
}
