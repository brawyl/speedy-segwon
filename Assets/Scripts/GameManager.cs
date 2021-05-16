using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public bool gameOver;
    public bool gameStart;
    public float crateInterval;
    public float spawnRange = 10f;
    public GameObject crate;
    public GameObject gameStartScreen;
    public GameObject gameOverScreen;

    private float timer = 0f;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;
        gameStart = false;
        gameOverScreen.SetActive(false);
        gameStartScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            float minutes = Mathf.Floor(timer / 60);
            float seconds = Mathf.RoundToInt(timer % 60);
            string timeString = "Time : ";

            if (minutes < 10)
            {
                timeString += "0" + minutes.ToString();
            }
            else
            {
                timeString += minutes.ToString();
            }
            timeString += ":";
            if (seconds < 10)
            {
                timeString += "0" + Mathf.RoundToInt(seconds).ToString();
            }
            else
            {
                timeString += Mathf.RoundToInt(seconds).ToString();
            }

            timerText.text = timeString;

            if (spawnTimer >= crateInterval)
            {
                spawnTimer = 0;
                float zSpawn = Random.Range(-spawnRange, spawnRange);
                Vector3 spawnPos = new Vector3(-100, 50, zSpawn);
                Instantiate(crate, spawnPos, transform.rotation);
            }
        }
        else
        {
            if (gameStart) { gameOverScreen.SetActive(true); }
        }
    }

    public void StartGame()
    {
        gameOver = false;
        gameStart = true;
        gameStartScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
