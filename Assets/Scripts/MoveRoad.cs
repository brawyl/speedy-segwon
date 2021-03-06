using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float repeatLength;
    private Vector3 startPos;
    private GameManager gameManager;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerController.speed);

            // If background moves down by its repeat length, move it back to start position
            if (transform.position.x > startPos.x + repeatLength)
            {
                transform.position = startPos;
            }
        }
    }
}
