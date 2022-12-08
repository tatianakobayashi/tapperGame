using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private float velocity;

    private void OnEnable()
    {
        velocity = Random.Range(2, 5);  
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Destroy(gameObject, 5f);
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
        }
    }
}
