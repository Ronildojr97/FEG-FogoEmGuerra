using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public AudioClip crashSoft;
    public AudioClip crashHard;

    private AudioSource source;
    public float dano;
    public static float danoMaximo = 0F;
    // sound system
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;

    
    void Awake()
    {
        danoMaximo = dano;
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Destroy(gameObject, 1.5F);
    }
     
    void OnCollisionEnter(Collision coll)
    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
        if (coll.relativeVelocity.magnitude < velocityClipSplit)
            source.PlayOneShot(crashSoft, hitVol);
        else
            source.PlayOneShot(crashHard, hitVol);
    }
}