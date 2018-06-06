using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigos : MonoBehaviour {
    public float vida;
    private float MaxVida;
    public Text textVida;
    public Slider sliderVida;
    public Rigidbody m_Rigidbody;


    private void Start()
    {
        m_Rigidbody.GetComponent<Rigidbody>();    
    }

    private void Awake()
    {
        sliderVida.value = vida;
        MaxVida = vida;
        textVida.text = MaxVida + "/" + vida.ToString();
    }

    private void Update()
    {
        m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Bala"))
        {
            vida -= BalaSystem.danoMaximo;
            //vida -= BalaSystem.dano;
            textVida.text = MaxVida+"/"+vida.ToString();
            sliderVida.value = vida;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
          
        }
    }

}
