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
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionNiño, "" });
                        break;

                    case "bus":
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionBus, "" });
                        break;

                    case "llanta":
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionLlanta, "" });
                        break;

                    case "op1":
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op1"), "" });
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op2":
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op2"), "" });
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op3":
                        mecanicaController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op3"), "" });
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;



                    default:
                        break;
                }

            }

        }

    }


}
