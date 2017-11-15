using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour {
    public float velocidadM;
    void Update () {
        this.transform.Translate(0, Time.deltaTime * velocidadM, 0);
    }
}
