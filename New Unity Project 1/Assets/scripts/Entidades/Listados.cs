using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.SqliteClient;
namespace Assets.scripts.Entidades
{
    public class Listados
    {
        // carga las partidas creadas por el usuario.
        public static List<Partida> cargarPartidas()
        {
            List<Partida> partidas = new List<Partida>();
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.sql_cargarPartidasUsuarios);
            while (odr.Read())
            {
            
                Partida opartida = new Partida(odr.GetInt32(3), "", odr.GetString(4));
                opartida.IdUsuario = odr.GetInt32(0);
                opartida.Ruta = odr.GetString(1).ToString();
                opartida.Descripcion = odr.GetString(2).ToString();



                partidas.Add(opartida);
            }

            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();

            return partidas;

        }
        public static List<Pregunta> cargarPreguntas(string nivel)
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.pregunta_listarPreguntas(nivel));
            while (odr.Read())
            {
                Pregunta unaPregunta = new Pregunta();                                        
                unaPregunta.IDPregunta = odr.GetInt32(0);
                unaPregunta.Nivel = new Nivel();
                unaPregunta.Nivel.IdNivel = odr.GetInt32(1);
                unaPregunta.Descripcion = odr.GetString(2);
                unaPregunta.Puntos = odr.GetString(3);
                preguntas.Add(unaPregunta);

            }
            if (odr != null)
            {
                if (!odr.IsClosed)
                    odr.Close();
            }
            oCnn.cerrar();


            for (int i = 0; i < preguntas.Count; i++)
            {
                preguntas[i].cargarRespuestas();
            }
           

            return preguntas;
        }


    }
}
