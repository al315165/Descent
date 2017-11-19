using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour {

	private GameObject controles;
	public Sprite pulsado;
	public Sprite noPulsado;

	// Use this for initialization
	void Start () {
		controles = GameObject.Find ("Controles");
		controles.SetActive (false);
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer> ().sprite = pulsado;
	}

	void OnMouseUp()
	{
		this.GetComponent<SpriteRenderer> ().sprite = noPulsado;
		controles.SetActive (true);
	}
}
