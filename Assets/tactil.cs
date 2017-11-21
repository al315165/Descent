using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tactil : MonoBehaviour {

	private personaje personajescript;

	// Use this for initialization
	void Start () {
		personajescript = GameObject.Find ("Protagonista").GetComponent<personaje> ();
	}

	public enum Lado
	{
		izq,
		der,
		sup,
		inf
	}

	public Lado tipotactil;

	void OnMouseDown()
	{
		if (tipotactil == Lado.der)
			personajescript.movimiento = 2;
		if (tipotactil == Lado.izq)
			personajescript.movimiento = 1;
		if (tipotactil == Lado.sup)
			personajescript.movimiento = 3;
		if (tipotactil == Lado.inf)
			personajescript.movimiento = 4;
	}

	void OnMouseOver()
	{
		
			
	}
	void OnMouseUp()
	{
		personajescript.movimiento = 0;
	}

}
