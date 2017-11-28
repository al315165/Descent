using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {

	public Text TextoDolor;

	public enum tipo
	{
		debil,
		medio,
		fuerte
	}
	public tipo tipoPersonaje;

	public void MostrarGolpe()
	{
		StartCoroutine (MostrarGolpeRoutina ());
	}

	IEnumerator MostrarGolpeRoutina()
	{
		if (tipoPersonaje == tipo.debil)
			TextoDolor.text = "15";
		else if (tipoPersonaje == tipo.medio)
			TextoDolor.text = "25";
		else if (tipoPersonaje == tipo.fuerte)
			TextoDolor.text = "50";

		yield return new WaitForSeconds (0.5f);

		TextoDolor.text = "";
	}
}
