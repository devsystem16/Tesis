using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using UnityEngine.SceneManagement;
public class ControllerMenuNuevoPersonaje : MonoBehaviour {



    public List<GameObject> jugadoresDisponibles;


    List<Usuario> usuarios;
    Usuario unUsuario;
    void Awake() {
        Usuario user = new Assets.scripts.Entidades.Usuario();
        usuarios = new List<Usuario>();
        usuarios = user.cargarUsuariosSinPartida();




        foreach (Usuario unUsuario in usuarios)
        {
            GameObject obj = GameObject.Find(unUsuario.Descripcion);
            string a = obj.name;
            obj.GetComponent<GUIText>().text = "disponible";

        }

        for (int i = 0; i < jugadoresDisponibles.Count; i++)
        {
            if (!jugadoresDisponibles[i].GetComponent<GUIText>().text.Equals("disponible"))
                jugadoresDisponibles[i].SetActive(false);
        }





    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {

        Debug.Log("asdasdasd");

        if (Input.GetMouseButton(0)) {

            GameObject objeto = gameObject;


            Debug.Log(objeto.name);

            switch (objeto.name)
            {

                case "btnAtras":
                    SceneManager.LoadScene("menuPersonaje");
                    break;


                case "jugador0":
                    unUsuario = new Usuario(); unUsuario.IdUsuario = 1;
                    unUsuario.cargar();
                    if (unUsuario.guardarPartida()) 
                        SceneManager.LoadScene("menuPersonaje");
                    
                    break;

                case "jugador1":
                    unUsuario = new Usuario(); unUsuario.IdUsuario = 2;
                    unUsuario.cargar();
                    if (unUsuario.guardarPartida())
                        SceneManager.LoadScene("menuPersonaje");
                    break;

                case "jugador2":
                    unUsuario = new Usuario(); unUsuario.IdUsuario = 3;
                    unUsuario.cargar();
                    if (unUsuario.guardarPartida())
                        SceneManager.LoadScene("menuPersonaje");
                    break;

                case "jugador3":
                    unUsuario = new Usuario(); unUsuario.IdUsuario = 4;
                    unUsuario.cargar();
                    if (unUsuario.guardarPartida())
                        SceneManager.LoadScene("menuPersonaje");
                    break;


                default:
                    break;
            }



        }



    }

}
