using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField] private int served;
    [SerializeField] private int clientsNotServed;
    [SerializeField] private int drinksNotServed;
    // Start is called before the first frame update
    void Start()
    {
        served = 0;
        clientsNotServed = 0;
        drinksNotServed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (clientsNotServed + drinksNotServed > served && !gameOver) gameOver = true;
    }

    public void AddServed()
    {
        served++;
    }

    public void AddClientNotServed()
    {
        clientsNotServed++;
    }

    public void AddDrinkNotServed()
    {
        drinksNotServed++;
    }
}
