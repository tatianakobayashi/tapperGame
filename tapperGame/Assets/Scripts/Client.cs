using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private float velocity;
    private GameController gameController;

    private void OnEnable()
    {
        velocity = Random.Range(2, 5);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Com delay???
        if (gameController.gameOver)
        {
            Debug.Log("Game OVER");
            Destroy(gameObject, 5f);
        }
        */
        Movement();
    }

    void Movement()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Drink"))
        {
            transform.parent = other.gameObject.transform;
            velocity = 0;
            other.gameObject.layer = gameObject.layer;
        }
        else if (other.collider.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
