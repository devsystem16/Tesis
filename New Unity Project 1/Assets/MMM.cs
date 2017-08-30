using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwipeMenu ;
public class MMM : MonoBehaviour {


 
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnMouseDown () {


		if (Input.GetMouseButton (0)) {



			GameObject obj = GameObject.Find ("Menu");
 
			Menu m = obj.GetComponent<Menu> ();

			m.set_currentMenuPosition (1.0f);
			m.UpdateMenuItemsPositionInWorldSpace (0f);


			//swipeHandler.mychael ();


		}
	}
}
