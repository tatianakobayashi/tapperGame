using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private bool isLeft;

    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!gameController.gameOver)
        {
            if (isLeft && other.gameObject.CompareTag("Drink") && other.gameObject.layer == 6)
            {
                gameController.AddServed();
            }
            else if (isLeft && other.gameObject.CompareTag("Drink"))
            {
                gameController.AddDrinkNotServed();
            }
            else if (!isLeft)
            {
                gameController.AddClientNotServed();
            }
        }
    }
}
