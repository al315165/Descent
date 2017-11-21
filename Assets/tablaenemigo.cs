using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablaenemigo : MonoBehaviour {

	public GameObject disparo;
	public GameObject disparoreal;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Disparo ();
	}

	public void Disparo()
	{
		disparoreal = Instantiate (disparo);
		disparoreal.SetActive (true);
		disparoreal.transform.parent = gameObject.transform;
		disparoreal.transform.position = disparo.transform.position;
	}
}
