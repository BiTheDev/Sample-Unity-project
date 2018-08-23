using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject shot;
    public Transform[] shotSpawn;
    public float fireRate;
    public float delay;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }
    void Fire()
    {
        for (int i = 0; i < shotSpawn.Length; i++)
        {
            Instantiate(shot, shotSpawn[i].position, shotSpawn[i].rotation);
        }
        audioSource.Play();
    }

}
