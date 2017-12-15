using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoClickN1 : MonoBehaviour {

	// Use this for initialization
 
	void Start () {
 
	}
	
	// Update is called once per frame
	void OnMouseDown ()
	{
		if (Input.GetMouseButton (0)) {
 
			GameObject objeto = gameObject;
			if (objeto != null) {
				Debug.Log (objeto.name);
				Color unC = new Color (1.000f, 1.000f, 1.000f, 1.000f);
				objeto.GetComponent<Renderer> ().material.color = (objeto.GetComponent<Renderer> ().material.color == Color.green) ? unC : Color.green;
			}


		}
 
	}
}

