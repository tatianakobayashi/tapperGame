using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClients : MonoBehaviour
{
    public float time;
    public GameObject[] prefabClients;
    public bool stop;

    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (stop)
        {
            time = Random.Range(1, 10);
            yield return new WaitForSeconds(time);
            if (!gameController.gameOver)
            {
                Instantiate(prefabClients[Random.Range(0, prefabClients.Length)], transform.position, Quaternion.identity);
            }
        }
    }
}
