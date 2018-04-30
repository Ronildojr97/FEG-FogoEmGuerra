using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float vida;
    public BalaSystem BalaSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bala"))
        {
            vida -= BalaSystem.dano;

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
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), vida+"/100");

    }
}
