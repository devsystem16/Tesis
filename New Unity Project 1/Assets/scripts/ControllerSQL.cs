using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts.Entidades;
public class ControllerSQL : MonoBehaviour {


    public static int limite_respuestas = 9;

    public static string escena_cargarEscena( string parametro) {
        return "select * from Escena where ruta='"+ parametro + "' or  IDEscena= '"+ parametro + "'"; 
    }



    public static string usuario_ObtenerusuarioSinPartidas = "   select * from  usuario where IDUsuario not in ( select IDUsuario from partida where estado=1)";

    public static string partida_cargarPartidaByid(  object IDPartida) {

        return " select  * from Partida where IDpartida = "+IDPartida+";";
    }



	public static string sql_cargarPartidasUsuarios = "select  u.IDUsuario , u.ruta , u.descripcion , p.IDPartida, P.fecha from Usuario u   inner  join Partida p  on u.IDUsuario = p.IDUsuario LIMIT 3";

    public static string usuario_obtenerCodigoPartida(object IDUsuario)
    {
        return "select  p.* from Usuario u   inner join Partida p  on u.IDUsuario = p.IDUsuario where u.IDUsuario= "+ IDUsuario + "  LIMIT 1";
    }


    public static string usuario_nivelActual(object IDusuario) {
        return "select   e.* from   Usuario u inner join Partida p on u.IDUsuario = p.IDUsuario inner join DetallePartida d on d.IDPartida = p.IDPartida inner join Escena e on e.IDEscena = d.IDEscena inner  join Nivel n on n.IDNivel = e.IDNivel  where u.IDUsuario = "+IDusuario+"  order by e.orden desc limit 1  ";
    }

    public static string pregunta_listarPreguntas(string nivel) {
        return "select * from Pregunta where IDNivel =" + nivel + " order by RANDOM();"; 
    }

   public static string pregunta_listarRespuestas(string nivel) {
        return "select * from ImagenRespuesta where IDPregunta =" + nivel + " order by RANDOM() limit  "+ limite_respuestas.ToString() + ";"; 
    }
    
    public static string usuario_consultarUsuario(int ID)
    {
        return "select u.* from Usuario u  where u.IDusuario = "+ ID + ";";
    }

    public static string nivelDefecto = "1_info";
    public static string sql_cargarNivel(string opcion ,  object usuario  ) {

        string sql = "";
        switch (opcion)
        {
            case "next":
                sql = "select * from Escena  ec where ec.orden = (  select   (e.orden+1) from DetallePartida dp  inner join Escena e on dp.IDEscena = e.IDEscena and dp.IDPartida = (select p.IDPartida from Partida p where idusuario = "+usuario+") order by e.orden desc limit 1  ) ";
                break;
            case "back":
                sql = "select * from Escena  ec where ec.orden = (  select   (e.orden-1) from DetallePartida dp  inner join Escena e on dp.IDEscena = e.IDEscena and dp.IDPartida = (select p.IDPartida from Partida p where idusuario = " + usuario + ") order by e.orden desc limit 1  ) ";
                break;
            case "last":
                sql = "select * from Escena  ec where ec.orden = (  select   (e.orden) from DetallePartida dp  inner join Escena e on dp.IDEscena = e.IDEscena and dp.IDPartida = (select p.IDPartida from Partida p where idusuario = " + usuario + ") order by e.orden desc limit 1  ) ";
                break;
            default:
                sql = "select * from Escena  ec where ec.orden = (  select   (e.orden) from DetallePartida dp  inner join Escena e on dp.IDEscena = e.IDEscena and dp.IDPartida = (select p.IDPartida from Partida p where idusuario = " + usuario + ") order by e.orden desc limit 1  ) ";
                break;

        }
        return sql;
    }
}
