using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSystem : MonoBehaviour {
    public float speed;
    public int dano;

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
