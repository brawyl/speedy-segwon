using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    public GameObject tomatoes;
    public GameObject explosion;
    public AudioClip explosionAudio;

    private GameManager gameManager;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerController.speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject explosionEffect = (GameObject)Instantiate(explosion, transform.position, explosion.transform.rotation).gameObject;
            Destroy(explosionEffect, 2.5f);

            AudioSource.PlayClipAtPoint(explosionAudio, gameManager.cameraPosition.position, 0.5f);


            Vector3 spawnPos = new Vector3(tomatoes.transform.position.x, tomatoes.transform.position.y, transform.position.z);
            Instantiate(tomatoes, spawnPos, tomatoes.transform.rotation);
        }

        Destroy(gameObject);
    }
}
