using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCameras : MonoBehaviour {

    // Use this for initialization


    public GameObject camaraEstacionamiento;
    public GameObject camaraMenuOperadores;
    public GameObject pistaDesdeAire;
    public GameObject techoAutobus;

	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void activarCamara(string camara) {

        switch (camara)
        {
            case "CamaraEstacionamiento":
                //pistaDesdeAire.SetActive(false);
                //techoAutobus.SetActive(false);
                camaraMenuOperadores.SetActive(false);
                camaraEstacionamiento.SetActive(true);
                break;

            case "CamaraMenuOperadores":
                camaraEstacionamiento.SetActive(false);
                //pistaDesdeAire.SetActive(false);
                //techoAutobus.SetActive(false);
                camaraMenuOperadores.SetActive(true);
                break;

            case "CamaraPistaDesdeAire":
                camaraEstacionamiento.SetActive(false);
                //techoAutobus.SetActive(false);
                camaraMenuOperadores.SetActive(false);
                //pistaDesdeAire.SetActive(true);
                break;

            case "CamaraTechoAutobus":
                camaraEstacionamiento.SetActive(false);
                camaraMenuOperadores.SetActive(false);
                //pistaDesdeAire.SetActive(false);
                //techoAutobus.SetActive(true);
                break;

            default:
                break;
        }

    }
}
