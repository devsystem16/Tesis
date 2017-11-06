using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionamientoController : MonoBehaviour {



    public GameObject ilustracionExpresion1;
    public GameObject ilustracionExpresion2;
    public GameObject ilustracionExpresion3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void asignarImagen(string rutaImagen) {

                if (!ilustracionExpresion1.activeInHierarchy)
                {
                    ilustracionExpresion1.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
                    ilustracionExpresion1.SetActive(true);
                }
                else if (!ilustracionExpresion2.activeInHierarchy)
                {
                    ilustracionExpresion2.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
                    ilustracionExpresion2.SetActive(true);
                }
                else {
                    ilustracionExpresion3.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
                    ilustracionExpresion3.SetActive(true);
                }
    }

}
