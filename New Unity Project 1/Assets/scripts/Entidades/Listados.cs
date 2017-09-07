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
		public static List<Partida> cargarPartidas() {
            List<Partida> partidas = new List<Partida>();
            MyDBConnection oCnn = new MyDBConnection();
            oCnn.conectar();
            IDataReader odr = oCnn.select(ControllerSQL.sql_cargarPartidasUsuarios);
            while (odr.Read())
            {
                Usuario ousuario = new Usuario(odr.GetInt32(0), odr.GetString(1).ToString(), odr.GetString(2));
                Partida opartida = new Partida(odr.GetInt32(3),ousuario , "" , odr.GetString(4));
                partidas.Add(opartida);
            }

			if (odr != null) {
				if (!odr.IsClosed)
					odr.Close ();
			}
			oCnn.cerrar ();

			return partidas;
                
        }

    }
}
