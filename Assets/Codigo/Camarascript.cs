using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarascript : MonoBehaviour {

	private GameObject Personaje;
	private personaje codigoPersonaje;
	public float velocidadcamaramax;
	public float velocidadcamaramin;

	// Use this for initialization
	void Awake () {
		Personaje = GameObject.FindGameObjectWithTag ("Player");
		codigoPersonaje = Personaje.GetComponent<personaje> ();

	}

	// Update is called once per frame
	void Update () {
		velocidadcamaramax = codigoPersonaje.velocidadMax;


		if (Personaje.transform.position.y < this.transform.position.y + 1.5f && Personaje.transform.position.y > this.transform.position.y - 1.5f  && codigoPersonaje.jugable)
			this.transform.Translate (Vector2.down * (velocidadcamaramax - 2f) * Time.deltaTime);
		else if (Personaje.transform.position.y > this.transform.position.y + 1.5f && codigoPersonaje.jugable)
			this.transform.Translate (Vector2.down * (velocidadcamaramax - 4f) * Time.deltaTime);
		else if (Personaje.transform.position.y < this.transform.position.y - 1.5f && codigoPersonaje.jugable)
			this.transform.Translate (Vector2.down * velocidadcamaramax * Time.deltaTime);

	}
}
