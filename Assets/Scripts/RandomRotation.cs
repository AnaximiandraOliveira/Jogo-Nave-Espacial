using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    void Awake()
    {

     rb = GetComponent<Rigidbody>();
     
    }
    void Start()
    {
        Vector3 angularVelocity = new Vector3 (Random.Range (-1, 1), Random.Range (-1, 1), Random.Range (-1, 1)).normalized;
        rb.angularVelocity = angularVelocity * speed;
    }

}
