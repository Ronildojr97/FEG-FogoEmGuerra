﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public Transform bala;
    public Transform target;

	void Update () {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, target.position, target.rotation);
        }
	}
}