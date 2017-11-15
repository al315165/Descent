using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playboton : MonoBehaviour {

	private personaje codigoPersonaje;


	// Use this for initialization
	void Awake () {
		codigoPersonaje = GameObject.FindGameObjectWithTag ("Player").GetComponent<personaje> ();
		
	}
	
	void OnMouseDown(){
		codigoPersonaje.velocidad = 6;
		codigoPersonaje.posicion = 1;
		this.gameObject.SetActive (false);
	}
}
