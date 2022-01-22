using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
 
    private AudioSource audioSource;

    public float delay;
    public float fireRate;

   void Awake()
   {

    audioSource = GetComponent<AudioSource> ();

   }


    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    
    void Update()
    {
        
    }

   void Fire()
   {

   Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
   audioSource.Play();

   }


}
