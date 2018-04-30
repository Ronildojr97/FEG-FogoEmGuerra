using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSystem : MonoBehaviour {
    public float speed;

    [Range(1.0F,10.0F)]
    public float dano = 5.5F;

    private void Start()
    {
        
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
