using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {

	public List<AudioClip> sonidos;
	public List<string> namesonido;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public  List<AudioClip> getSonidos (){
		return sonidos;
	
	}
	public  List<string> getSNameSonidos (){
		return namesonido;

	}
}
