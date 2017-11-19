using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonOpciones : MonoBehaviour {

	private Animator animacion;
	public Sprite pulsado;
	public Sprite noPulsado;


	// Use this for initialization
	void Start () {
		animacion = GameObject.Find ("Botones").GetComponent<Animator> ();
	}

	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer> ().sprite = pulsado;
	}

	void OnMouseUp()
	{
		this.GetComponent<SpriteRenderer> ().sprite = noPulsado;
		animacion.SetBool ("tipo", true);
	}
	
	// Update is called once per frame

}
