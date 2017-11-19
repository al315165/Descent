using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volver : MonoBehaviour {

	private Animator animacion;


	void Start () {
		animacion = GameObject.Find ("Botones").GetComponent<Animator> ();
	}
	
	void OnMouseDown()
	{
		animacion.SetBool ("tipo", false);
	}
}
