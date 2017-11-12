using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour {

	public float velocidad;
	public int direccion;
	public int posicion;


	// Update is called once per frame
	void Update () {
		//activa siempre
		this.transform.Translate (0, -Time.deltaTime * velocidad, 0);

		if (Input.GetKeyDown (KeyCode.A))
			direccion = 1;
		if (Input.GetKeyDown (KeyCode.D))
			direccion = 2;
		

		switch (posicion) {
		case 1:
			if (direccion == 1) {
				if (this.transform.localPosition.x > -1.5f)
					this.transform.Translate (-Time.deltaTime * velocidad, 0, 0);
				else {
					direccion = 0;
					posicion = 0;
				}
					
			} else if (direccion == 2) {
				if (this.transform.localPosition.x < 1.5f)
					this.transform.Translate (Time.deltaTime * velocidad, 0, 0);
				else {
					posicion = 2;
					direccion = 0;
				}
			}
			break;
		case 2:
			if (direccion == 1) {
				if (this.transform.localPosition.x > 0)
					this.transform.Translate (-Time.deltaTime * velocidad, 0, 0);
				else {
					direccion = 0;
					posicion = 1;
				}
			} else if (direccion == 2)
				direccion = 0;
			break;
		case 0:
			if (direccion == 2) {
				if (this.transform.localPosition.x < 0)
					this.transform.Translate (Time.deltaTime * velocidad, 0, 0);
				else {
					direccion = 0;
					posicion = 1;
				}
			} else if (direccion == 1)
				direccion = 0;
			break;
		}

	}
}
