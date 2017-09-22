using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
using UnityEngine.SceneManagement;
public class ControllerMenuNuevoPersonaje : MonoBehaviour {



    public List<GameObject> jugadoresDisponibles;


    List<Usuario> usuarios;
    void Awake() {
        Usuario user = new Assets.scripts.Entidades.Usuario();
        usuarios = new List<Usuario>();
        usuarios = user.cargarUsuariosSinPartida();


        for (int i = 0; i < jugadoresDisponibles.Count; i++)
          jugadoresDisponibles[i].SetActive(false);


            GameObject obsssj = GameObject.Find("jugador2");
        obsssj.SetActive(false);
         

        for (int i = 0; i < jugadoresDisponibles.Count; i++)
            jugadoresDisponibles[i].SetActive(true);
        //foreach (Usuario unUsuario in usuarios) {
        //    GameObject obj = GameObject.Find(unUsuario.Descripcion);
        //    obj.SetActive(true);

        //}





    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown() {


        if (Input.GetMouseButton(0)) {

            GameObject objeto = gameObject;


            Debug.Log(objeto.name);

            switch (objeto.name)
            {

                case "btnAtras":
                    SceneManager.LoadScene("menuPersonaje");
                    break;




                
                default:
                    break;
            }



        }



    }

}
