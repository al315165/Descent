using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorniveles : MonoBehaviour {

	public GameObject contenedorNivelesGo;
	public GameObject[] contenedorNiveles1Array;
	public GameObject[] contenedorNiveles2Array;
	public GameObject[] contenedorNiveles3Array;
	public GameObject[] contenedorNiveles4Array;
	public GameObject[] contenedorNiveles5Array;
	public GameObject[] contenedorTransicion1Array;
	public GameObject[] contenedorTransicion2Array;
    public GameObject[] contenedorTransicion3Array;
	public GameObject[] contenedorTransicion4Array;
   


    public GameObject Nivel;

	public int contadorniveles=0;
	int contadorcontenedor = 0;
	int numeroselectorNivel1;
	int numeroselectorNivel2;
	int numeroselectorNivel3;
	int numeroselectorNivel4;
	int numeroselectorNivel5;
	int numeroselectorTransicion1;
	int numeroselectorTransicion2;
	int numeroselectorTransicion3;
	int numeroselectorTransicion4;

	public GameObject nivelAnterior;
	public GameObject nivelNuevo;

	public float tamañoNivel;

	public Vector3 medidaLimitePantalla;
	public bool saliodePantalla;
	public bool saliodenivel = false;
	public GameObject nCamGo;
	public Camera nCamComp;

	// Use this for initialization
	void Start () {
		InicioJuego ();
	}

	void InicioJuego(){

		contenedorNivelesGo = GameObject.Find ("ContenedorNiveles");
		nCamGo = GameObject.Find ("MainCamera");
		nCamComp = nCamGo.GetComponent<Camera> ();
		MedirPantalla ();
		BuscoNiveles ();

	}

	void BuscoNiveles(){

		contenedorNiveles1Array = GameObject.FindGameObjectsWithTag ("nivelprimero");
		contenedorNiveles2Array = GameObject.FindGameObjectsWithTag ("nivelsegundo");
		contenedorNiveles3Array = GameObject.FindGameObjectsWithTag ("niveltercero"); 
		contenedorNiveles4Array = GameObject.FindGameObjectsWithTag("nivelcuarto");
		contenedorNiveles5Array = GameObject.FindGameObjectsWithTag("nivelquinto");

		contenedorTransicion3Array = GameObject.FindGameObjectsWithTag ("transicion3");
		contenedorTransicion1Array = GameObject.FindGameObjectsWithTag ("transicion1");
		contenedorTransicion2Array = GameObject.FindGameObjectsWithTag ("transicion2");
		contenedorTransicion4Array = GameObject.FindGameObjectsWithTag ("transicion4");

        HacerHijos (contenedorNiveles1Array);
		HacerHijos (contenedorNiveles2Array);
		HacerHijos (contenedorNiveles3Array);
		HacerHijos(contenedorNiveles4Array);
		HacerHijos(contenedorNiveles5Array);
		HacerHijos (contenedorTransicion1Array);
		HacerHijos (contenedorTransicion2Array);
        HacerHijos(contenedorTransicion3Array);
		HacerHijos(contenedorTransicion4Array);


		CrearNiveles ();
	}

	void HacerHijos (GameObject[] contenedor)
	{
		for (int i = 0; i < contenedor.Length; i++) {

			contenedor [i].gameObject.transform.parent = contenedorNivelesGo.transform;
			contenedor [i].gameObject.SetActive (false);
			contenedor [i].gameObject.name = "NivelOFF" + contadorcontenedor;
			contadorcontenedor++;
		}
	}

	public void CrearNiveles ()
	{
		contadorniveles++;
		numeroselectorNivel1 = Random.Range (0, contenedorNiveles1Array.Length);
		numeroselectorNivel2 = Random.Range (0, contenedorNiveles2Array.Length);
		numeroselectorNivel3 = Random.Range (0, contenedorNiveles3Array.Length);
		numeroselectorNivel4 = Random.Range (0, contenedorNiveles4Array.Length);
		numeroselectorNivel5 = Random.Range (0, contenedorNiveles5Array.Length);


		if (contadorniveles < 5) {
			Nivel = Instantiate (contenedorNiveles1Array [numeroselectorNivel1]);
		} else if (contadorniveles < 6) {
			Nivel = Instantiate (contenedorTransicion1Array [0]);
		} else if (contadorniveles < 11) {
			Nivel = Instantiate (contenedorNiveles2Array [numeroselectorNivel2]);
		} else if (contadorniveles < 12) {
			Nivel = Instantiate (contenedorTransicion2Array [0]);
		} else if (contadorniveles < 17)
			Nivel = Instantiate (contenedorNiveles3Array [numeroselectorNivel3]);
		else if (contadorniveles < 18) {
			Nivel = Instantiate (contenedorTransicion3Array [0]);
		} 
		else if (contadorniveles < 23) {
			Nivel = Instantiate (contenedorNiveles4Array [numeroselectorNivel4]);
		} 
		else if (contadorniveles < 24) {
			Nivel = Instantiate (contenedorTransicion4Array [0]);
		} 
		else {
			Nivel = Instantiate (contenedorNiveles5Array [numeroselectorNivel5]);
		}


		Nivel.SetActive (true);
		Nivel.name = "Nivel" + contadorniveles;
		Nivel.transform.parent = gameObject.transform;
		PosicionoNiveles ();
	}

	void PosicionoNiveles(){

		nivelAnterior = GameObject.Find ("Nivel" + (contadorniveles - 1));
		nivelNuevo = GameObject.Find ("Nivel"+ contadorniveles);
		MidoNivel ();
		nivelNuevo.transform.position = new Vector3 (nivelAnterior.transform.position.x,
			nivelAnterior.transform.position.y - tamañoNivel, 0);
		saliodePantalla = false;
		saliodenivel = false;
	}

	void MidoNivel(){

		for (int i = 0; i < nivelAnterior.transform.childCount; i++) {
			if (nivelAnterior.transform.GetChild (i).gameObject.GetComponent<Pieza> () != null) {
				float tamañopieza = nivelAnterior.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
				tamañoNivel = tamañoNivel + tamañopieza;
			}
		}

	}

	void MedirPantalla ()
	{
		medidaLimitePantalla = new Vector3 (0,nCamComp.ScreenToWorldPoint(new Vector3 (0,0,0)).y +0.5f,0);
	}



	void Update ()
	{
		if (saliodenivel == true && saliodePantalla == false) {

			saliodePantalla = true;
			DestruyoNiveles ();
		}
	}

	void DestruyoNiveles()
	{
		Destroy (nivelAnterior);
		tamañoNivel = 0;
		nivelAnterior = null;
		CrearNiveles ();
	}
}
