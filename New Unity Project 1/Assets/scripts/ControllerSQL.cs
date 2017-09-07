using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSQL : MonoBehaviour {

	public static string sql_cargarPartidasUsuarios = "select  u.IDUsuario , u.ruta , u.descripcion , p.IDPartida, P.fecha from Usuario u   inner  join Partida p  on u.IDUsuario = p.IDUsuario LIMIT 3";

}
