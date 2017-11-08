using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacionamientoController : MonoBehaviour {



    public GameObject ilustracionExpresion1;
    public GameObject ilustracionExpresion2;
    public GameObject ilustracionExpresion3;

    public GameObject Estadocorrecto;
    public GameObject Estadoincorrecto;



    // Use this for initialization
    private List<string>    listaNumeroBuses;
    private int pivot;
    void Awake() {
        listaNumeroBuses = new List<string>();

        for (int i = 0; i < 3; i++)
        {
            string dato = (Mathf.Round(Random.Range(1f, 30f))).ToString();
            if (!listaNumeroBuses.Contains(dato)) {
                listaNumeroBuses.Add(dato);
            }
        }

    } 
    void Start()
    {
        
      
        GameObject numeroBus1 = GameObject.Find("numeroBus1"); numeroBus1.GetComponent<TextMesh>().text = listaNumeroBuses[0];
        GameObject numeroBus2 = GameObject.Find("numeroBus2"); numeroBus2.GetComponent<TextMesh>().text = listaNumeroBuses[1];
        GameObject numeroBus3 = GameObject.Find("numeroBus3"); numeroBus3.GetComponent<TextMesh>().text = listaNumeroBuses[2];

 
        Text  textoProblema =  GameObject.Find("Text").GetComponent<Text>() ;
          pivot = int.Parse(Mathf.Round(Random.Range(0f, 2f)).ToString());
        textoProblema.text = "Seleccione el bus con placa  " +listaNumeroBuses[pivot] + "  a Jaime"
;

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


            string bs = "bus" + listaNumeroBuses[pivot];
            if (Constantes.concatenar(exprecion).Equals("jaime,igual," + bs))
            {

                Estadocorrecto.SetActive(true);
            }
            else {
                Estadoincorrecto.SetActive(true);
                StartCoroutine(incorrecto());
            }
 

        }
    }


    IEnumerator incorrecto() {
        yield return new WaitForSeconds(3f);

        Estadoincorrecto.SetActive(false);
        ilustracionExpresion1.SetActive(false);
        ilustracionExpresion2.SetActive(false);
        ilustracionExpresion3.SetActive(false);
    }

}
