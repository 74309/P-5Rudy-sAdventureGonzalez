using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void FixedUpdate()
    {
        Vector2 postion = rigidbody2D.position;

        if (vertical)
        {
            postion.y = postion.y + Time.deltaTime * speed;
        }
        else
        {
            postion.x = postion.x + Time.deltaTime * speed;
        }

        rigidbody2D.MovePosition(postion);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RudyController player = other.gameObject.GetComponent<RudyController>();

        if (player != null)
        {
            player.ChangeHealth(direction - 1);
        }
    }
}
