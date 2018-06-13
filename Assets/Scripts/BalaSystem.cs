using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSystem : MonoBehaviour {
    public float speed;
    public float dano;
    public static float danoMaximo = 0F;

    private void Awake()
    {
        danoMaximo = dano; // calcular o dano por velocidade   
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(0,0,speed*Time.deltaTime);
        Destroy(gameObject, 1.5F);
    }


    private void OnTriggerEnter(Collider other) { 
        Destroy(gameObject);
    }
    
}
