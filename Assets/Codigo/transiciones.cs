using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transiciones : MonoBehaviour {

	public int escena;

	public void cambiarEscena ()
	{
		SceneManager.LoadScene (escena);
	}

}
