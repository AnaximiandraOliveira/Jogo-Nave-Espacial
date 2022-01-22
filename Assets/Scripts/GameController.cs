using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject [] asteroides;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;
    public float timeWait;

    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    public bool restart;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
      UpdateSpawnValues ();
      restart = false;
      gameOver = false;
      gameOverText.gameObject.SetActive (false);
      restartText.gameObject.SetActive (false);

       StartCoroutine (SpawnAsteroid());
       score= 0;
       UpdateScore();
    }

    void UpdateSpawnValues()
    {

      Vector2 half = Utils.GetDimensionInWorldUnits() / 2;
      spawnValues = new Vector3 (half.x - 0.7f, 0f, half.y + 6f);

    }

        void Update()
     {
          if (Input.GetKeyDown (KeyCode.R) && restart)
         {
           SceneManager.LoadScene (0);
         }

     }

    
    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds (startWait);

        while(true)
        {

        for(int i=0; i < asteroidCount; i++)
        {
        GameObject asteroid = asteroides[Random.Range(0, asteroides.Length)];
        Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),  spawnValues.y, spawnValues.z);
        Instantiate (asteroid, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds (spawnWait);
        }
     
         yield return new WaitForSeconds (timeWait);

         if (gameOver)
         {
           restartText.gameObject.SetActive (true);
           restart = true;
           break;
         }


        }

    }

    void UpdateScore(){

      scoreText.text = "Pontos:" + score;
    }

public void AddScore(int value)
{
  score += value;
  UpdateScore ();

}

public void GameOver()
{
gameOverText.gameObject.SetActive(true);
gameOver = true;

}

}

