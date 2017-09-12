using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSQL : MonoBehaviour {

	public static string sql_cargarPartidasUsuarios = "select  u.IDUsuario , u.ruta , u.descripcion , p.IDPartida, P.fecha from Usuario u   inner  join Partida p  on u.IDUsuario = p.IDUsuario LIMIT 3";

    public static string sql_cargarNextNivel(int avance) {
        return "select * from Escena  ec where ec.orden = (  select   (e.orden) from DetallePartida dp  inner join Escena e on dp.IDEscena = e.IDEscena and dp.IDPartida = (select p.IDPartida from Partida p where idusuario = 1) order by e.orden asc limit 1  ) ";
    }
}
