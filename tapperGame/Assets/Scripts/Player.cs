using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int sideVelocity;

    [SerializeField] private GameObject drink;
    [SerializeField] private List<Transform> locations;
    [SerializeField] private List<Transform> drinkLocations;
    private int currentLocation;
    private float initialX;
    private bool isMovingLeft;

    private GameController gameController;
    void Start()
    {
        transform.position = locations[0].position;
        initialX = transform.position.x;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        isMovingLeft = transform.position.x < initialX;
        if (!gameController.gameOver)
        {
            Movement();
            SideMovement();
            MakeDrink();
        }
        else
        {
            transform.position = locations[0].position;
            currentLocation = 0;
        }
    }

    void Movement()
    {
        if (!isMovingLeft)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentLocation > 0) currentLocation--;
                ChangePosition();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentLocation < 2) currentLocation++;
                ChangePosition();
            }
        }
    }

    void ChangePosition()
    {
        transform.position = new Vector2(transform.position.x, locations[currentLocation].position.y);
    }

    void SideMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -9)
        {
            transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
        }
        else if (isMovingLeft)
        {
            transform.Translate(sideVelocity * Time.deltaTime, 0, 0);
        }
    }

    void MakeDrink()
    {
        if (!isMovingLeft && Input.GetKeyDown(KeyCode.Space))
            Instantiate(drink, drinkLocations[currentLocation].position, Quaternion.identity);
    }
}
