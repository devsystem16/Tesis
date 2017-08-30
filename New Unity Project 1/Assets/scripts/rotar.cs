using UnityEngine;
using System.Collections;

public class rotar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
         
	}
}
