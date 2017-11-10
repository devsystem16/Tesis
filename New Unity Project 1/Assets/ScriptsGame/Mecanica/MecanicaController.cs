using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaController : MonoBehaviour {



    public List<GameObject> ilustraciones;

	public GameObject Estadocorrecto;
	public GameObject Estadoincorrecto; 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void asignarImagen(object[] parametros  )
    {
        string rutaImagen = parametros[0].ToString();
        string numeroBus = parametros[1].ToString();

	 
		 
        for (int i = 0; i < ilustraciones.Count; i++)
        {
            GameObject oIlustracion = ilustraciones[i];

            // Verificar si esta activa.
			if (oIlustracion.activeInHierarchy == false)
            {
                oIlustracion.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(rutaImagen);
                oIlustracion.SetActive(true);
				oIlustracion.GetComponent<GUIText>().text = rutaImagen.Substring(rutaImagen.LastIndexOf("\\")+1);


				if (i == (ilustraciones.Count - 1)) {
					// validar respuesta.
					validarResultado (ilustraciones);
				
					break;

				} else {
					break;
				}
             

            } // End if 

		

        } // End For

	 
 
    } // End  void.

	void validarResultado( List<GameObject> expresion) {

		if (Constantes.concatenar (expresion).Equals ("niño,igual,bus,bus,igual,llanta,llanta,igual,niño")
		
			||  Constantes.concatenar (expresion).Equals ("niño,igual,llanta,llanta,igual,bus,bus,igual,niño")
		) {
			Estadocorrecto.SetActive (true);

			 
		} else {
			Estadoincorrecto.SetActive(true);
			StartCoroutine (Incorrecto ());

	 
		}
		Debug.Log ("Validar");
    }


	IEnumerator Incorrecto (){
	
		yield return new WaitForSeconds (3f);
		for (int i = 0; i < ilustraciones.Count; i++) {
			ilustraciones [i].SetActive (false);
		}

		Estadoincorrecto.SetActive(false);
	}

}
