using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject projetil;
    public float shootSpeed = 2000;
    public AudioClip shootSound;
    private AudioSource source;

    private float volumeLowRange = .5F;
    private float volumeHighRange = 1.0F;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            // volume randomico
            float vol = Random.Range(volumeLowRange, volumeHighRange);

            source.PlayOneShot(shootSound,vol);
            GameObject launch = Instantiate(projetil, transform.position, transform.rotation) as GameObject;
            launch.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, shootSpeed));
        }
	}
}
/*
  public GameObject projetil;
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
               // tiro.Play();
                StartCoroutine(time());
                Instantiate(bala, target.position, target.rotation);
                isPodeAtirar = false;

            }
        }
        else
        {
            if (isPodeAtirar)
            {
               // tiro.Play();
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

     */
