using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBtn : MonoBehaviour {

	public Sprite pulsado;
	public Sprite noPulsado;
	public Text texto;
	public GameObject caja;
	public DatosGuardar datos;

	void Awake()
	{
		datos = GameObject.Find ("GuardadoDatos").GetComponent<DatosGuardar> ();
	}


	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer> ().sprite = pulsado;
	}

	void OnMouseUp()
	{
		this.GetComponent<SpriteRenderer> ().sprite = noPulsado;
		caja.SetActive (true);
		texto.text = " Puntuación: " + Convert.ToString (datos.DarPuntuacion()); 

	}
}
