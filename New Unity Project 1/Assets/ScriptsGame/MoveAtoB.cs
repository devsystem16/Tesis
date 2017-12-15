using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtoB : MonoBehaviour {



	public List<Transform> PuntosPosicionamiento ;
	public float velocidadArranqueBus; 
	public float volicidadGiro =1;
	int  indicePuntos = 1 ;
	private string StatusGame  = "idle";




	public List<Transform> puntosRotacion;

	// Use this for initialization
	void Start () {
		StatusGame = "run";
	}


	public void movePoint(string move) {
		if (move.Equals ("next")) {
			if (indicePuntos <  PuntosPosicionamiento.Count -1)
				indicePuntos++;
		} else if (move.Equals ("back")) {
			if (indicePuntos >  0)
				indicePuntos--;
		}
	}


 
	public  void moveTo (Transform point){
		float step = velocidadArranqueBus * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, point.position, step);


	}



	void Update () {

		// Verificar el estado del juego.
		if (StatusGame.Equals ("run")) {
		
			moveTo (PuntosPosicionamiento [indicePuntos]);
			// Cuando llega al punto.
			if (transform.position == PuntosPosicionamiento [indicePuntos].position) {
				setStatusGame ("idle");
			} 

		 

		} else if (StatusGame.Equals ("idle")) {
			 //   Debug.Log (PuntosPosicionamiento [indicePuntos].gameObject.name);

			if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointA")) {
				StartCoroutine (wait (2f));
				movePoint ("next");
				setStatusGame ("run");
			} else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointB")) {
				turn ("right");
				movePoint ("next");
				setStatusGame ("run");
			} else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointC")) {
				StartCoroutine (wait (2f));
				movePoint ("next");
				setStatusGame ("run");
			} else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointD")) {
				turn ("left");
				movePoint ("next");
				setStatusGame ("run");
			} else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointE")) {
				turn ("left");
				movePoint ("next");
				setStatusGame ("run");
			} else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointF")) {
				turn ("left");
				movePoint ("next");
				indicePuntos = 0;
				setStatusGame ("run");
			}
			else if (PuntosPosicionamiento [indicePuntos].gameObject.name.Equals ("pointInit")) {
				turn ("park");
				indicePuntos = 0;
				setStatusGame ("stop");
			}

		} else if (StatusGame.Equals ("stop")) {
		
		
		}



	}



	public  void turn (string   direccion ){
		if (direccion.Equals ("left")) {
	 StopAllCoroutines ();
			StartCoroutine (Rotate (-90));
		} else if (direccion.Equals ("right")) {
		 	StopAllCoroutines ();
			StartCoroutine (Rotate (90));
		}
		else if (direccion.Equals ("park")) {
			StopAllCoroutines ();
			StartCoroutine (Rotate (180));
		}

	}

	IEnumerator Rotate(float rotationAmount){
		Quaternion finalRotation = Quaternion.Euler (0, rotationAmount, 0) * transform.rotation;
		while (this.transform.rotation != finalRotation) {
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, finalRotation, Time.deltaTime * volicidadGiro);
			yield return 0;
			 
		}
	}

	IEnumerator  wait (float seconds ){
		yield return new WaitForSeconds (seconds);
	}



	public string getStatusGame (){
		return this.StatusGame;
	}
	public  void setStatusGame (string status) {
		this.StatusGame = status;
	}



	void OnTriggerEnter  (Collider collider){
	
		Debug.Log ("Entro triggers");


	}

}
