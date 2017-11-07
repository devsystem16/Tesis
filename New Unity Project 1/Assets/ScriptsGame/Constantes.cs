using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constantes : MonoBehaviour {
 

    public static string rutaInteraccionPersona = @"Interaccion\jaime";
    public static string rutaInteraccionBus = @"Interaccion\bus";
    public static string rutaOperador(string numeroOperador) {
        string ruta = "";
        switch (numeroOperador)
        {
            case "op1":
                ruta = @"operadores\igual";
                break;

            case "op2":
                ruta = @"operadores\igualigual";
                break;

            case "op3":
                ruta = @"operadores\expresion";
                break;
        }
        return ruta;
    }


    public static string concatenar(List<GameObject> listaObjetos) {
        string cadena = "";
        for (int i = 0; i < listaObjetos.Count; i++)
        {
            cadena += listaObjetos[i].GetComponent<GUIText>().text.Trim().Replace("\n","").Replace("▼", "")  + ( (listaObjetos.Count == (i+1) ) ? "" : ",");
        }
        return cadena;
    }

}
