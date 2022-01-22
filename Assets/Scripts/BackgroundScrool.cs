using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrool : MonoBehaviour
{
    
 private Vector3 startPosition;
 private float tilesize;
 public float scroolspeed;


    void Start()
    {
        startPosition = transform.position;
        tilesize = transform.localScale.y;
    }




    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scroolspeed, tilesize);
        transform.position = startPosition + Vector3.forward * newPosition;
}
}
