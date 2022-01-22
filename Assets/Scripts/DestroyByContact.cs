using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;

    void Start ()
    {
     gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();

    }


    void OnTriggerEnter(Collider col)
    {
     
     if(col.tag == "Boundary" || col.tag == "Enimy" )
     {
         return;
     }


    if(explosion !=null)
         {
         
    Instantiate (explosion, transform.position, transform.rotation);
         }
    
       if(col.CompareTag ("Player"))
     {
         
         Instantiate (playerExplosion, col.transform.position, col.transform.rotation);
         gameController.GameOver ();
     }

     if(col.tag == "Bala")
     {
         gameController.AddScore(scoreValue);
     }
     
     
     Destroy(col.gameObject);
     Destroy(gameObject);
    
    }

 

}