using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionamientoClick : MonoBehaviour {





    public EstacionamientoController estacionamientoController;


    public ControllerCameras controllerCameras;
    

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            // obtendo el gameObject que el usuario le ah dado click.
            GameObject objeto = gameObject;
            // valido que el objeto seleccionado  no sea nullo.
            if (objeto != null)
            {
 
                switch (objeto.name)
                {
                    case "bus1":
                        // enviar  parametros de que imagen y número de bus se seleccionaron.
                        estacionamientoController.SendMessage("asignarImagen",  new object [] { Constantes.rutaInteraccionBus, GameObject.Find("numeroBus1").GetComponent<TextMesh>().text });

                        break;

                    case "bus2":
                        // enviar  parametros de que iamgen y número de bus se seleccionaron.
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionBus, GameObject.Find("numeroBus2").GetComponent<TextMesh>().text });
                        break;

                    case "bus3":
                        // enviar  parametros de que iamgen y número de bus se seleccionaron.
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionBus, GameObject.Find("numeroBus3").GetComponent<TextMesh>().text });

                        break;

                    case "personaEstacionamiento":
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaInteraccionPersona ,""});
                        break;

                    case "op1":
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op1") ,""} );
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op2":
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op2"), "" });
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;

                    case "op3":
                        estacionamientoController.SendMessage("asignarImagen", new object[] { Constantes.rutaOperador("op3"), "" });
                        controllerCameras.SendMessage("activarCamara", "CamaraEstacionamiento");
                        break;


                    default:
                        break;
                }


            

            }
        }
    }   
}
