using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerProgreso : MonoBehaviour {

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
            GameObject objeto = gameObject;
            switch (objeto.name)
            {
                case "btnAtras":
                    SceneManager.LoadScene("menuPersonaje");
                    break;

                case "jugador0_progress":
                    SceneManager.LoadScene("Multiple Menu Scene");
                    break;
                case "jugador1_progress":
                    SceneManager.LoadScene("Multiple Menu Scene");
                    break;
                case "jugador2_progress":
                    SceneManager.LoadScene("Multiple Menu Scene");
                    break;

                default:
                    break;
            }



          
        }
    }



}
