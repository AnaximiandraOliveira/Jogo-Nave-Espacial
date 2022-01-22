using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit{

public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour
{
    [Header("Movimentos")]
   private Rigidbody rb;
   public float speed;
   public Limit limit;
   public float tilt;
   
   [Header("Disparos")]
   public GameObject shot;
   public Transform shotSpaw;
   public float fireRate;
   public float nextFire;

   private AudioSource audioSource;

   void Awake ()
   {
       rb = GetComponent<Rigidbody> ();

   }

   void FixedUpdate()
   {
    
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");
    Vector3 mov = new Vector3 (moveHorizontal, 0f ,moveVertical);
    rb.velocity = mov * speed;
    rb.position = new Vector3 (Mathf.Clamp(rb.position.x, limit.xMin, limit.xMax), 0f, Mathf.Clamp(rb.position.z, limit.zMin, limit.zMax));
    rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x*-tilt);

   }


    void Start()
    {
        UpdateBoundary ();
    }

    void UpdateBoundary()
    {
   
       Vector2 half = Utils.GetDimensionInWorldUnits() / 2;
       limit.xMin = -half.x + 0.7f;
       limit.xMax = half.x - 0.7f;
       limit.zMin = -half.y + 6f;
       limit.zMax = half.y - -2f;
    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetButton("Fire1") && Time.time > nextFire){
             nextFire = Time.time + fireRate;
        Instantiate (shot, shotSpaw.position, Quaternion.identity);
        audioSource.Play();

        }
    }
}
