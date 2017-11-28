using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour {
    public float velocidadM;
	personaje codigoPersonaje;

	void Awake()
	{
		codigoPersonaje = GameObject.Find ("Protagonista").GetComponent<personaje> ();
	}
    void Update () {

		if (codigoPersonaje.jugable)
        	this.transform.Translate(0, Time.deltaTime * velocidadM, 0);
    }
}
