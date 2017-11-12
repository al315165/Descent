using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour {

	private GameObject transicion;

	void Awake ()
	{
		transicion = GameObject.Find ("Fondonegrofin");
		transicion.SetActive (false);
	}

	void OnMouseDown()
	{
		transicion.SetActive (true);
	}
}
