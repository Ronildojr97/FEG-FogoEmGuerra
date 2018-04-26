using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public Transform bala;
    public Transform target;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          //  Debug.Log(bala.tag);
            Instantiate(bala, target.position, target.rotation);
        }
    }
}
