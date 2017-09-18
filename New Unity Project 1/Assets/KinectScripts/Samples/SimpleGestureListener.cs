using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;
using  SwipeMenu ;
public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;
	
	
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
			string sGestureText = string.Format ("{0} {1:F1}% complete", gesture, progress * 100);
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

	int imgSeleccionada =   1 ;
	private  int CantidaClick =0 ;
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
 
			if(sGestureText == "SwipeLeft"){


				GameObject obj = GameObject.Find ("Menu");
				Menu m = obj.GetComponent<Menu> ();
				m.set_currentMenuPosition (1.0f);
				m.UpdateMenuItemsPositionInWorldSpace (0f);




				/*


			GameObject cuboPresent = GameObject.Find("PresentationCube");
			PresentationScript clsPresentacion =  cuboPresent.GetComponent<PresentationScript>();
			clsPresentacion.Siguienteimg();

			//	GameObject + objinfo = GameObject.Find("cuadroDeInformacion");
				 
				imgSeleccionada -- ;
				if (imgSeleccionada > 4  ){
					imgSeleccionada = 1 ;
				}
				
				if (imgSeleccionada <1  ){
					imgSeleccionada =  4;
				}
			
				objRespuesta.GetComponent<Text> ().text = imgSeleccionada.ToString();
				sGestureText += string.Format(   "Imagen seleccionada: " + imgSeleccionada.ToString());

				*/
			}
			if(sGestureText == "SwipeRight"){

				GameObject obj1 = GameObject.Find ("Menu");
				Menu m1 = obj1.GetComponent<Menu> ();
 					m1.set_currentMenuPosition (-1.0f);
					m1.UpdateMenuItemsPositionInWorldSpace (0f);
			 
 

 


			/*	GameObject cuboPresent = GameObject.Find("PresentationCube");
				PresentationScript clsPresentacion =  cuboPresent.GetComponent<PresentationScript>();
				clsPresentacion.AnteriorImg();
				imgSeleccionada  ++ ;
				
				if (imgSeleccionada > 4  ){
					imgSeleccionada = 1 ;
				}
				
				if (imgSeleccionada <1  ){
					imgSeleccionada =  4;
				}
				sGestureText += string.Format(   "Imagen seleccionada: " + imgSeleccionada.ToString());
				  
				objRespuesta.GetComponent<Text> ().text = imgSeleccionada.ToString();*/
			}


			if(sGestureText == "Psi"){

				// Clic en el boton de silencio.
				GameObject objSound = GameObject.Find ("musica");
				bool estado = !objSound.GetComponent<AudioSource> ().mute;
				objSound.GetComponent<AudioSource> ().mute = estado;
				GameObject btnMusica = GameObject.Find ("btnMusica");
				GameObject cuboPresent = GameObject.Find("objImagenes");
				Imagenes clsImagenes =  cuboPresent.GetComponent<Imagenes>();
				btnMusica.GetComponent<Renderer> ().material.mainTexture = clsImagenes.GetImagenes () [  ((estado == true )? 1:0 )];


			}

 




			if (sGestureText == "Push") {

				darClickizquierdo ();
		
				GameObject objNivel = GameObject.Find ("nivel");
				string nivel = objNivel.GetComponent<Text> ().text;
			 
				if (nivel.Equals ("s1")) {
					CantidaClick++;

					if (CantidaClick == 2) {
						SceneManager.LoadScene ("level1");
						CantidaClick = 0;
					}


				}

				if (nivel.Equals ("s2")) {
					CantidaClick++;

					if (CantidaClick == 2) {
						SceneManager.LoadScene ("KinectAvatarsDemo");
						CantidaClick = 0;
					}


				}
				 

				GameObject cursorPush = GameObject.Find("HandCursor");
				Double x =  Convert.ToDouble ( Math.Round ( cursorPush.transform.position.x ,2));
				Double y =  Convert.ToDouble ( Math.Round  ( cursorPush.transform.position.y,2 ));

				sGestureText += ( "X: " +x.ToString()+ "    Y: " + y.ToString()  );





			}

			

        }
		progressDisplayed = false;
		return true;
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
