using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaClick : MonoBehaviour {


    public MecanicaController mecanicaController;
    public ControllerCameras controllerCameras;

     
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnMouseDown() {

        if (Input.GetMouseButton(0))
        {

            // obtendo el gameObject que el usuario le ah dado click.
            GameObject objeto = gameObject;
            // valido que el objeto seleccionado  no sea nullo.
            if (objeto != null)
            {
                switch (objeto.name)
                {
                    case "niñoMecanica":
					mecanicaController.SendMessage("validarRespuesta",  "niño");
                        break;

                    case "bus":
					mecanicaController.SendMessage("validarRespuesta", "bus");
                        break;

                    case "llanta":
					mecanicaController.SendMessage("validarRespuesta", "llanta");
                        break;

                    case "asignacion":
					mecanicaController.SendMessage("validarRespuesta", "igual");
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op2":
					mecanicaController.SendMessage("validarRespuesta", "comparacion");
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op3":
					mecanicaController.SendMessage("validarRespuesta", "");
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;



                    default:
                        break;
                }

            }

        }

    }


}
