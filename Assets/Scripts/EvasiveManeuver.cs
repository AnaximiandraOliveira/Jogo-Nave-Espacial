using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    
   public Vector2 startWait;
   private float targetManeuver;
   public float dodge;
   private Rigidbody rb;
   public float smoothing;
   public Vector2 maneuverTime;
   public Vector2 maneuverWait;
   

   void Awake()
   {
       rb = GetComponent<Rigidbody>();
   }

    void Start()
    {
        StartCoroutine (Evade ());
    }



    void Update()
    {
        
    }


    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);

      rb.velocity = new Vector3(newManeuver, 0f, rb.velocity.z);

    }

    IEnumerator Evade()
    {
     
     yield return new WaitForSeconds (Random.Range(startWait.x, startWait.y));

     while (true)
     {
     targetManeuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x);
     yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));
     targetManeuver =0;
     yield return new WaitForSeconds (Random.Range(maneuverWait.x, maneuverWait.y));
     
     }

    }

}

