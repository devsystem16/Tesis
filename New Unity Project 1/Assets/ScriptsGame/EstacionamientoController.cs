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
 
    public void asignarImagen(object[] parametros /*string rutaImagen, string numeroBus*/) {


        string rutaImagen = parametros[0].ToString();
        string numeroBus = parametros[1].ToString();

        if (!ilustracionExpresion1.activeInHierarchy)
        {
            ilustracionExpresion1.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion1.SetActive(true);

            ilustracionExpresion1.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\")+1)+ numeroBus;

        }
        else if (!ilustracionExpresion2.activeInHierarchy)
        {
            ilustracionExpresion2.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion2.SetActive(true);
            ilustracionExpresion2.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\") + 1) + numeroBus;

        }
        else {
            ilustracionExpresion3.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
            ilustracionExpresion3.SetActive(true);
            ilustracionExpresion3.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\") + 1) + numeroBus;
 
            List<GameObject> exprecion = new List<GameObject>();
            exprecion.Add(ilustracionExpresion1);
            exprecion.Add(ilustracionExpresion2);
            exprecion.Add(ilustracionExpresion3);
 
             
            if (Constantes.concatenar(exprecion).Equals("jaime,igul,bus40")) {

                Debug.Log("Correcto");
            }
 

        }
    }

}
