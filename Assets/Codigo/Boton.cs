using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour {

	private GameObject transicion;
	public Sprite pulsado;
	public Sprite noPulsado;

	void Awake ()
	{
		transicion = GameObject.Find ("Fondonegrofin");
		transicion.SetActive (false);
	}

	void OnMouseDown()
	{
		GetComponent<SpriteRenderer> ().sprite = pulsado;
	}

	void OnMouseUp()
	{
		GetComponent<SpriteRenderer> ().sprite = noPulsado;
		transicion.SetActive (true);
	}
}
