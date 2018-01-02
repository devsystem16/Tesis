using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCameras : MonoBehaviour {

    // Use this for initialization


    public GameObject camaraEstacionamiento;
    public GameObject camaraMenuOperadores;
    public GameObject pistaDesdeAire;
    public GameObject techoAutobus;

	 

	public GameObject menuOperadores ;
	public GameObject canvas;
	public List<GameObject> objetosOcultables ;

	public void mostrarEscena ( int activo){
		bool estado = (activo ==1) ? true : false ;
		for (int i = 0; i < objetosOcultables.Count; i++) {
			objetosOcultables [i].SetActive (estado);
		}
	}





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
			camaraMenuOperadores.SetActive (false);
			camaraEstacionamiento.SetActive (true);
			menuOperadores.SetActive (false);
			canvas.SetActive (true);
			mostrarEscena (1);
                break;

		case "CamaraMenuOperadores":
			camaraEstacionamiento.SetActive (false);
			camaraMenuOperadores.SetActive (true);
			menuOperadores.SetActive (true);
			canvas.SetActive (false);
			mostrarEscena (0);
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
