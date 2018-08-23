using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public GameObject boss;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text RestartText;
    public Text GameOverText;

    // player health

    //public Text HPText;

    private int waves;
    private bool gameOver;
    private bool restart;
    public int score;

    // player health
    //private  int startingHealth = 100;

     void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        waves = 1;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves()) ;
        //UpdateHealth();
    }

     void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        if(Input.GetKey("escape")){
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(waves<3){
            waves++;
            for (int i = 0; i <= hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver){
                RestartText.text = "Press 'R' To Restart!!";
                restart = true;
                break;
            }

        }
        if(waves == 3){
            SpawnBoss();
        }
  
    }
    public void SpawnBoss(){
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(boss, spawnPosition, spawnRotation);
        if (gameOver)
        {
            RestartText.text = "Press 'R' To Restart!!";
            restart = true;
        }
    }
    public void GameOver(){
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void AddScore(int newScoreValue){
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore(){
        scoreText.text = "Score:" + score;
    }


    // Player health change

    //public void PlayerGetDamage(int damage){
    //    startingHealth -= damage;
    //    if(startingHealth <= 0){
    //        startingHealth = 0;
    //    }
    //    UpdateHealth();
    //}
    //void UpdateHealth(){
    //    HPText.text = "HP:" + startingHealth;

    //}

}
