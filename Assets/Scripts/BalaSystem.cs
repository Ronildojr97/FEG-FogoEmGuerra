using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSystem : MonoBehaviour {
    public float speed;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0,0,speed*Time.deltaTime);
        Destroy(gameObject, 1.5F);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemies")
        {
            other.gameObject.SetActive(false);
           // Destroy(other, 1F);
        }
    }
}
