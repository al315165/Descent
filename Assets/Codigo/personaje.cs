using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour {

	public float velocidad;
	public int direccion;
	public int posicion;
    public float velocidadSubida;
    public generadorniveles generadorNcomp;
    public int escena;

    Animator animador;

	void Awake()
	{
		generadorNcomp = GameObject.Find ("GeneradorNiveles").GetComponent<generadorniveles> ();
        animador = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () {
		//activa siempre
		this.transform.Translate (0, -Time.deltaTime * velocidad, 0);

        animador.SetBool("Idle", true);
        animador.SetBool("Left", false);
        animador.SetBool("Right", false);
        animador.SetBool("Up", false);
        animador.SetBool("Down", false);
        if (Input.GetKey(KeyCode.A) && this.transform.localPosition.x > -3.5f)
        {
            
            animador.SetBool("Idle", false);
            animador.SetBool("Left", true);
            this.transform.Translate(-Time.deltaTime * velocidad, 0, 0);
            
        }
       

        if (Input.GetKey(KeyCode.D) && this.transform.localPosition.x < 3.5f)
        {
            animador.SetBool("Idle", false);
            animador.SetBool("Right", true);
            this.transform.Translate(Time.deltaTime * velocidad, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && this.transform.localPosition.y < -3.5f)
        {
            animador.SetBool("Idle", false);
            animador.SetBool("Up", true);
            this.transform.Translate(0, Time.deltaTime * (velocidad/2), 0);
        }

        if (Input.GetKey(KeyCode.S) && this.transform.localPosition.y > this.transform.localPosition.y - 3.5f)
        {
            animador.SetBool("Idle", false);
            animador.SetBool("Down", true);
            this.transform.Translate(0, -Time.deltaTime * (velocidad/2), 0);
            
        }

    }


    /*if (Input.GetKeyDown (KeyCode.A))
        direccion = 1;
    if (Input.GetKeyDown (KeyCode.D))
        direccion = 2;
    if (Input.GetKeyDown(KeyCode.W))
        direccion = 3;
    if (Input.GetKeyDown(KeyCode.S))
        direccion = 4;*/
    /*  switch (posicion) {
  case 1:
      if (direccion == 1) {
          if (this.transform.localPosition.x > -3.5f)
              this.transform.Translate (-Time.deltaTime * velocidad, 0, 0);
          else {
              direccion = 0;
              posicion = 0;
          }

      } else if (direccion == 2) {
          if (this.transform.localPosition.x < 3.5f)
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
  case 3:

         if (direccion == 4)
          {
              if (this.transform.localPosition.y > -3.5f)
                  this.transform.Translate(0, -Time.deltaTime * velocidad, 0);
              else {
                  direccion = 0;
                  posicion = 4;
              }
          }
          else if (direccion == 3)
              direccion = 0;
          break;

   case 4:
          if (direccion == 3)
          {
              if (this.transform.localPosition.y < 3.5f)
                  this.transform.Translate(0, Time.deltaTime * velocidad, 0);
              else {
                  direccion = 0;
                  posicion = 3;
              }
          }
          else if (direccion == 4)
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
  }*/




    void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
		case "generanivel":
			Debug.Log ("genera");
			generadorNcomp.saliodenivel = true;
			if (velocidad < 9.0f)
				velocidad += 0.2f;
			break;
       case "enemigo" :
                SceneManager.LoadScene(escena);
                break;
        }
	}

   

}
