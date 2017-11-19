using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour {

	public GameObject padre;

	void OnMouseDown()
	{
		padre.SetActive (false);
	}
	

}
