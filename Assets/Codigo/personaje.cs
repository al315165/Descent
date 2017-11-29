using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class personaje : MonoBehaviour {

	public float velocidad;
	public float velocidadMax;
	public float velocidadMin;
	public int direccion;
	public int posicion;
	public float velocidadSubida;
	public generadorniveles generadorNcomp;
	public int escena;
	private int puntuacion;
	public Text textoPuntuacion;
	private DatosGuardar datos;
	Animator animador;
	Camarascript scriptCamara;
	public bool jugable;

	//salud
	public Slider slidersalud;
	private int salud= 100;

	void Awake()
	{
		generadorNcomp = GameObject.Find ("GeneradorNiveles").GetComponent<generadorniveles> ();
		animador = GetComponent<Animator>();
		datos = GameObject.Find ("GuardadoDatos").GetComponent<DatosGuardar> ();
		scriptCamara = Camera.main.GetComponent<Camarascript> ();
		jugable = false;
	}


	// Update is called once per frame
	void Update () {

		//activa siempre
		if (jugable) {
			this.transform.Translate (Vector2.down * velocidad * Time.deltaTime);

			animador.SetBool ("Idle", true);
			animador.SetBool ("Left", false);
			animador.SetBool ("Right", false);
			animador.SetBool ("Up", false);
			animador.SetBool ("Down", false);
		}
		if (Input.GetKey(KeyCode.A) && jugable && this.transform.position.x > -3.5f)
		{

			animador.SetBool("Idle", false);
			animador.SetBool("Left", true);
			this.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
		}


		if (Input.GetKey(KeyCode.D) && jugable && this.transform.position.x < 3.5f)
		{
			animador.SetBool("Idle", false);
			animador.SetBool("Right", true);
			this.transform.Translate(Vector2.right * velocidad * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.W) && jugable)
		{
			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
				animador.SetBool ("Idle", false);
				animador.SetBool ("Up", true);
			}
			if (velocidad > velocidadMin)
				velocidad-= 2.0f;
			Debug.Log ("pulsar");

		}
		if (!Input.GetKey (KeyCode.W) && velocidad== velocidadMin && jugable) {
			velocidad+=2.0f;
			Debug.Log ("soltar");
		}

		if (Input.GetKey(KeyCode.S) && jugable)
		{
			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
				animador.SetBool ("Idle", false);
				animador.SetBool ("Down", true);
			}
			if (velocidad < velocidadMax)
				velocidad+=2.0f;
		}
		if (!Input.GetKey (KeyCode.S) && velocidad == velocidadMax && jugable) {
			velocidad-=2.0f;
		}
	}



	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
		case "generanivel":
			Debug.Log ("genera");
			generadorNcomp.saliodenivel = true;
			if (velocidad < 7.0f) {
				velocidad += 0.1f;
				velocidadMax += 0.1f;
				velocidadMin += 0.1f;
			}
			textoPuntuacion.text = Convert.ToString(Convert.ToInt32 (textoPuntuacion.text)+5);
			break;
		case "enemigo":
			Enemigo scriptEnemigo = other.GetComponent<Enemigo> ();
			scriptEnemigo.MostrarGolpe ();
			if (salud > 0) {
				if (scriptEnemigo.tipoPersonaje == Enemigo.tipo.debil) {
					salud -= 15;
					slidersalud.value -= 15;
				} else if (scriptEnemigo.tipoPersonaje == Enemigo.tipo.medio) {
					salud -= 25;
					slidersalud.value -= 25;
				} else if (scriptEnemigo.tipoPersonaje == Enemigo.tipo.fuerte) {
					salud -= 50;
					slidersalud.value -= 50;
				}
			}
			if (salud <= 0) {
				/*if ( Convert.ToInt32(textoPuntuacion.text)> datos.DarPuntuacion())
				{
					datos.Guardar (Convert.ToInt32 (textoPuntuacion.text));
				}
				SceneManager.LoadScene(escena);
				*/
			}
			break;
		}
	}



}
