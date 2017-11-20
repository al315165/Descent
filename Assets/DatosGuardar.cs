using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DatosGuardar : MonoBehaviour {

	private string ruta;
	private int punt;


	// Use this for initialization
	void Awake () {
		ruta = Application.persistentDataPath + "/puntuacion";
		Debug.Log (ruta);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Guardar(int puntos)
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (ruta);

		DatosPuntuacion dat = new DatosPuntuacion ();

		dat.puntuacion = puntos;

		bf.Serialize (file, dat);
		file.Close ();
	}
	public int DarPuntuacion()
	{
		if (File.Exists (ruta)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (ruta, FileMode.Open);

			DatosPuntuacion datos = (DatosPuntuacion)bf.Deserialize (file);

			punt = datos.puntuacion;
			file.Close ();
			return punt;

		} 
		else
			return 0;
	}
}

[Serializable]
class DatosPuntuacion
{
	public int puntuacion;
}