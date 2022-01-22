using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   private Rigidbody rb;
   public float speed;

   void Awake(){

    rb = GetComponent<Rigidbody>();
}
    
    void Start()
    {
        rb.velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
