using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float zRange = 8f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float currentX = transform.position.x;
            float currentY = transform.position.y;

            if (transform.position.z < -zRange)
            {
                transform.position = new Vector3(currentX, currentY, -zRange);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(currentX, currentY, zRange);
            }

            Vector3 move = new Vector3(currentX, currentY, horizontalInput) * Time.deltaTime * speed;
            transform.Translate(move);
        }
    }
}
