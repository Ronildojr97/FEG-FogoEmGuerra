using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour {
    public float vida;
   // private float MaxVida;
   // public Text textVida;
    //public Slider sliderVida;

    private void Awake()
    {
       // sliderVida.value = vida;
       // MaxVida = vida;
        //textVida.text = MaxVida + "/" + vida.ToString();
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Bala"))
        {
            vida -= ShootingSystem.danoMaximo;
            Debug.Log(vida);
            //vida -= BalaSystem.dano;
           // textVida.text = MaxVida+"/"+vida.ToString();
          //  sliderVida.value = vida;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
          
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bala")
        {
            vida -= ShootingSystem.danoMaximo;
            Debug.Log(vida);
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
