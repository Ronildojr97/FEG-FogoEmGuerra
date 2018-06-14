using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float vidaMax;
    public float vida;

    private void Awake()
    {
        vidaMax = vida;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bala"))
        {
            //vida -= BalaSystem.dano;
            Debug.Log(vida);
            if (vida <= 0)
            {
                Destroy(gameObject);
            }

        }
        if (other.tag.Equals("Enemies"))
        {
                Destroy(gameObject);
        }
    }

}
