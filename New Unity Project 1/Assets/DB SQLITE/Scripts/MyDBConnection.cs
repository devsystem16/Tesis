using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using Mono.Data.SqliteClient;

public class MyDBConnection : MonoBehaviour {

	private IDbConnection oCnn;
	private IDbCommand oComando ;
	private IDataReader odr;

	private string dbFile = "URI=File:dbGame.db";
	// Use this for initialization
	void Start () {
		
	}
	
	public void conectar(){
		oCnn = new SqliteConnection (dbFile);
		oComando = oCnn.CreateCommand ();
		oCnn.Open ();
	}

	public void cerrar (){
	
		oComando = null;
		 
		if (odr != null) {
			if (!odr.IsClosed) {
				odr.Close ();
			}
			odr = null;
		}
		oCnn.Close ();
	}
	public void seelccionar (string sqlQuery){
		oComando.CommandText = sqlQuery;
		odr= oComando.ExecuteReader ();
		while (odr.Read ()) {
			Debug.Log (odr.GetString (1));
		}
	}

    public IDataReader select (string sqlQuery)
    {
        oComando.CommandText = sqlQuery;
        odr = oComando.ExecuteReader();
        return odr;
    }
    public void sqlIAE (string sqlQuery){
		oComando.CommandText = sqlQuery;
		oComando.ExecuteNonQuery ();
	}

}
