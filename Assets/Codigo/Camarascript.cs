using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarascript : MonoBehaviour {

	private GameObject Personaje;
	private personaje codigoPersonaje;

	// Use this for initialization
	void Awake () {
		Personaje = GameObject.Find ("Personaje");
		codigoPersonaje = Personaje.GetComponent<personaje> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Personaje.transform.localPosition.y <= this.transform.localPosition.y) 
		{
			this.transform.Translate (0, -Time.deltaTime * codigoPersonaje.velocidad, 0);
		}

	}
}
