using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public bool isEnemies = false;
    public Transform bala;
    public Transform target;
    private bool isPodeAtirar = true;
    public float breakTime;
    public AudioSource tiro;

    private void FixedUpdate()
    {
        if (!isEnemies)
        {
            if (Input.GetAxisRaw("Fire1") != 0 && isPodeAtirar)
            {
                tiro.Play();
                StartCoroutine(time());
                Instantiate(bala, target.position, target.rotation);
                isPodeAtirar = false;

            }
        }
        else
        {
            if (isPodeAtirar)
            {
                tiro.Play();
                StartCoroutine(time());
                Instantiate(bala, target.position, target.rotation);
                isPodeAtirar = false;
            }
        }
    }

    IEnumerator time() {
        yield return new WaitForSeconds(breakTime);
        isPodeAtirar = true;
    }
}
