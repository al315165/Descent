using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class salirPunt : MonoBehaviour {

	public GameObject padre;
	public Text texto;


	void OnMouseDown()
	{
		texto.text = "";
		padre.SetActive (false);
	}
}
