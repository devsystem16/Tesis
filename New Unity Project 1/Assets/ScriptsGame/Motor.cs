using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {




	private  float runStyle = 0;
	public float speed=20;
	public float curve = 10 ;
	public  float deltaTime = 0.02f;
 


	 
	public GameObject bus  ;
	void FixedUpdate (){


	}

	// Use this for initialization
	void Start () {
		runStyle = speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (new Vector3 (0, 0, speed* Time.deltaTime) );
		}

 
	 
	//	transform.Translate (Vector3.forward * runStyle * 0.02f );
		 
 

	}

	void OnTriggerStay  (Collider collider){


		if (collider.gameObject.name.Equals ("giroDerecha")) {
			Debug.Log(collider.gameObject.name);
			runStyle =curve;
			bus.transform.Rotate (new Vector3 (0f, 40f, 0f) * Time.deltaTime);
		
		} else 	if (collider.gameObject.name.Equals ("giroIzquierda")) {
			Debug.Log(collider.gameObject.name);
			runStyle =curve;
			bus.transform.Rotate (new Vector3 (0f, -40f, 0f) * Time.deltaTime);
		
		}

		// else 	if (collider.gameObject.name.Equals ("giroIzquierda")) {

			 
	//	}
 

	}
 


	void OnTriggerEnter (Collider collider){

		Debug.Log ("Entro");
	}
	void OnTriggerExit (Collider collider){
		runStyle	 = speed  ;
		Debug.Log("salio " + collider.gameObject.name  + "   " + collider.gameObject.transform.position  );

  
	}





} 