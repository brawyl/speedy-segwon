using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public AudioClip countAudio;

    private int Count = 0;
    private GameManager gameManager;

    private void Start()
    {
        Count = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        AudioSource.PlayClipAtPoint(countAudio, gameManager.cameraPosition.position, 0.7f);

        if (Count >= 200)
        {
            gameManager.gameOver = true;
        }
    }
}
