using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
public class Jugador : MonoBehaviour {

    private Usuario usuario;

    public Usuario Usuario
    {
        get
        {
            return usuario;
        }

        set
        {
            usuario = value;
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
