using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClsGameController : MonoBehaviour {


	 public List<GameObject> opcionesRespuestas;
	//public List<Texture> imagenesParaOpciones;
	 

 

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



	void OnMouseDown ()
	{


		if (Input.GetMouseButton (0)) {
			GameObject objClick = gameObject;

			switch (objClick.name) {

			case "btnOk":


			//	string escenaActua =	SceneManager.GetActiveScene ().name;
			 

				string objSeleccionados = "";
				for (int i = 0; i < opcionesRespuestas.Count; i++) {
					if (opcionesRespuestas [i].GetComponent<Renderer> ().material.color == Color.green) {
						objSeleccionados += " " + opcionesRespuestas [i].name; 
					}
				}
				Debug.Log (objSeleccionados);
				break;

			}
		}

	}
}
