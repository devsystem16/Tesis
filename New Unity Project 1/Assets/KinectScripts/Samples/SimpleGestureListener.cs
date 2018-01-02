using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;
using  SwipeMenu ;
public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{




	public GameObject gesto1;
	public GameObject gesto2;
	public GameObject gesto3;
	public GameObject gesto4;
	public GameObject gesto1Er;
	public GameObject gesto2Er;
	public GameObject gesto3Er;
	public GameObject gesto4Er;

	public ClsMostrarMensajes clsMostrarMensajes;

	public TextMesh problema;
	public GameObject menuIteraccion ;
	public GameObject canvasPreguntaUsuario;
	public GameObject camaraBus;
	public GameObject numIteraciones;




	public GameObject menuSemaforo;
	public  GameObject paso1if; 
	public  GameObject paso2if; 
	public  GameObject paso3if; 
	public  GameObject paso4if; 



	// info texto
	public Text txtInstruccion;
	public Text txtPergamino;

	public Text txtInstruccionPantallaCiclos ;


	public string gestoRealizado ="";
	public  string getGestoRealizado () {
	
		return   this.gestoRealizado;
	}
	void Awake (){
		 
	}


	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;


    public ControllerCameras controllerCameras;
 
	public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
//		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);
		
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeUp);
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeDown);
		
		if(GestureInfo != null)
		{
		//	GestureInfo.GetComponent<GUIText>().text = "SwipeLeft, SwipeRight, Jump or Squat.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
		if (gesture == KinectGestures.Gestures.Click && progress > 0.3f) {
			string sGestureText = string.Format ("{0} {1:F1}% procesando", gesture, progress * 100);
			if (GestureInfo != null)
				GestureInfo.GetComponent<GUIText> ().text = sGestureText;
			
			progressDisplayed = true;
		} else if ((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f) {
			string sGestureText = string.Format ("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if (GestureInfo != null)
				GestureInfo.GetComponent<GUIText> ().text = sGestureText;
			
			progressDisplayed = true;
		} else if (gesture == KinectGestures.Gestures.Wheel && progress > 0.5f) {
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if (GestureInfo != null)
				GestureInfo.GetComponent<GUIText> ().text = sGestureText;
			
			progressDisplayed = true;
		} 

 
/*else if (gesture == KinectGestures.Gestures.Push && progress > 0.1f) {
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if (GestureInfo != null)
				GestureInfo.GetComponent<GUIText> ().text = sGestureText;
			
			progressDisplayed = true;

			
		}
	 */
	}


	public  void darClickizquierdo (){
	
		GameObject hand = GameObject.Find("HandCursor");
		float x1 =   System.Convert.ToSingle(  ( hand.transform.position.x ));
		float y1 =   System.Convert.ToSingle (  ( hand.transform.position.y ));
		Vector3 v3 = new Vector3 (x1 ,y1, 0.1f);
		MouseControl.MouseMove (v3,GestureInfo  );
		MouseControl.MouseClick ();
		Cursor.visible = true ;
		GameObject objSonidos = GameObject.Find("sonidos");
		Sonidos Clssonidos = objSonidos.GetComponent<Sonidos> ();

		List<AudioClip> audioS = Clssonidos.GetComponent<Sonidos> ().getSonidos ();
		List<String> nameSonidos = Clssonidos.GetComponent<Sonidos> ().getSNameSonidos ();

		for (int i = 0; i < nameSonidos.Count; i++) {
			if (nameSonidos[i] == "click") {
				Transform posicion = transform;
				AudioClip clic = audioS[i];
				AudioSource.PlayClipAtPoint (clic, posicion.position, 1.0f);
				break;
			}
		}

	}

	//int imgSeleccionada =   1 ;
	//private  int CantidaClick =0 ;



	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		// para saber que opcion selecciono el usuario.
		//GameObject objRespuesta = GameObject.Find ("opcionSeleccionada");

		string sGestureText = gesture +"";
		if (gesture == KinectGestures.Gestures.Click) {
			// sGestureText += string.Format (" at ({0:F2}, {1:F2})", screenPos.x, screenPos.y);
			darClickizquierdo ();
		}

        if (GestureInfo != null)
        {
            GestureInfo.GetComponent<GUIText>().text = sGestureText;

			// condicional if
			if (sGestureText == "Tpose")
			{
				gestoRealizado = "if";
				Debug.Log("Condicional");
			

				if (problema.text.Equals ("pr2")) {
				

					gesto2.SetActive (true);
					clsMostrarMensajes.PrintMensaje ("correcto", "Muy bien,  la acción condicional permitira tomar una decisión al llegar a un semáforo.", 5f);

					StartCoroutine (interaccion ("pr2_if", 5f));


				
				
				}


			}

			// Operadores
            if (sGestureText == "Wave")
            {
				gestoRealizado = "operadores";
                Debug .Log("Abrir operadores");
                controllerCameras.SendMessage("activarCamara", "CamaraMenuOperadores");
            }

			// Aumentar contador 
            if (sGestureText == "SwipeLeft"){
				gestoRealizado = "contador++";
				Debug.Log("Contador ++");
				float numero = float.Parse (numIteraciones.GetComponent<TextMesh> ().text);
				numero++;
				numIteraciones.GetComponent<TextMesh> ().text = numero.ToString ();
			}

			// Decrementar contador.
			if(sGestureText == "SwipeRight"){
				gestoRealizado = "contador--";
				Debug.Log("Contador --");

				float numero = float.Parse (numIteraciones.GetComponent<TextMesh> ().text);
				if (numero > 0)
				numero--;
				numIteraciones.GetComponent<TextMesh> ().text = numero.ToString ();

			}

			// While
			if (sGestureText == "RaiseRightHand") {
				gestoRealizado = "while";
				Debug.Log("While");
			}

			// Do While
			if (sGestureText == "RaiseLeftHand") {
				gestoRealizado = "doWhile";
				Debug.Log("Do while");


				if (problema.text.Equals ("pr1")) {
					gesto4Er.SetActive (true);
					clsMostrarMensajes.PrintMensaje ("error", "Lo siento, te has equivocado", 3f);

					StartCoroutine (interaccion ("errorEnFor" , 3f));
				//	gesto4Er.SetActive (false);
				}


			}

			//  For
			if(sGestureText == "Psi"){
				Debug.Log("For");

				gestoRealizado = "for";
				if (problema.text.Equals ("pr1")) {
 					

					gesto1.SetActive (true);


					clsMostrarMensajes.PrintMensaje ("correcto", "Muy bien, la acción repetir hasta se utiliza para iterar cuando se conoce el límite.  " , 5f);
					StartCoroutine (interaccion ("pr1_for" , 5f));

		 
				}

				// Clic en el boton de silencio.
			/*	GameObject objSound = GameObject.Find ("musica");
				bool estado = !objSound.GetComponent<AudioSource> ().mute;
				objSound.GetComponent<AudioSource> ().mute = estado;
				GameObject btnMusica = GameObject.Find ("btnMusica");
				GameObject cuboPresent = GameObject.Find("objImagenes");
				Imagenes clsImagenes =  cuboPresent.GetComponent<Imagenes>();
				btnMusica.GetComponent<Renderer> ().material.mainTexture = clsImagenes.GetImagenes () [  ((estado == true )? 1:0 )];
				*/
			}



			if (sGestureText == "Push") {
				darClickizquierdo ();
			}

			

        }
		progressDisplayed = false;
		return true;
	}



	IEnumerator interaccion(string cual , float tiempo){  

		if (cual.Equals ("pr1_for")) {
			yield return new WaitForSeconds (tiempo);
			txtInstruccionPantallaCiclos.text = txtInstruccion.text;
			camaraBus.SetActive (false); 
			menuIteraccion.SetActive (true);
			canvasPreguntaUsuario.SetActive (false);
			gesto1.SetActive (false);
		} else if (cual.Equals ("pr2_if")) {
			yield return new WaitForSeconds (tiempo);


			canvasPreguntaUsuario.SetActive (false);
			camaraBus.SetActive (false);

			menuSemaforo.SetActive (true);
			paso1if.SetActive (true);
			gesto2.SetActive (false);
		 
		} else if (cual.Equals ("errorEnFor")) {
			yield return new WaitForSeconds (tiempo);

			gesto4Er.SetActive (false);

		} 
	}










	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}
	
     }
