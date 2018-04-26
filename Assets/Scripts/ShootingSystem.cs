using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public Transform bala;
    public Transform target;
    private bool isPodeAtirar = true;
    public float breakTime;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isPodeAtirar)
        {
            StartCoroutine(time());
            Instantiate(bala, target.position, target.rotation);
            isPodeAtirar = false;

        }
    }

    IEnumerator time() {
        yield return new WaitForSeconds(breakTime);
        isPodeAtirar = true;
    }
}
