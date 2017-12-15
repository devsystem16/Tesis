using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoBus : MonoBehaviour {



	public Semaforo semaforo ;
	public MoveAtoB moveAtoB ;



	public Semaforo semaforo2;
	public Semaforo semaforo3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider collider){


		 
		if (collider.name.Equals ("triggerSemaforo")) {
		
		 
			if (semaforo.getStatusSemaforo ().Equals ("rojo")) {
				moveAtoB.setStatusGame ("stop");
			} else {
				
				if (moveAtoB.getStatusGame ().Equals ("stop")) {
					moveAtoB.setStatusGame ("run");
				}

			}


			 
		}



		if (collider.name.Equals ("triggerSemaforo2")) {


			if (semaforo2.getStatusSemaforo ().Equals ("rojo")) {
				moveAtoB.setStatusGame ("stop");
			} else {

				if (moveAtoB.getStatusGame ().Equals ("stop")) {
					moveAtoB.setStatusGame ("run");
				}

			}



		}




		if (collider.name.Equals ("triggerSemaforo3")) {


			if (semaforo3.getStatusSemaforo ().Equals ("rojo")) {
				moveAtoB.setStatusGame ("stop");
			} else {

				if (moveAtoB.getStatusGame ().Equals ("stop")) {
					moveAtoB.setStatusGame ("run");
				}

			}



		}


	 


	
	}
}
