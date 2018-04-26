using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour {
    public int vida;
    public BalaSystem BalaSystem;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Bala"))
        {
            vida -= BalaSystem.dano;

            if (vida <= 0)
            {
                Destroy(gameObject);
            }
          
        }
    }

}
