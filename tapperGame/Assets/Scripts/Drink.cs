using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    private float speed = 5f;

    void Start()
    {

    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Finish")) Destroy(gameObject);
    }
}
