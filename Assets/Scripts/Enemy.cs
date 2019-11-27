using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointValue;

    private Rigidbody2D body;

    [SerializeField]
    private float speed;
    private Vector2 movementDirection;
    
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        movementDirection = Vector2.right;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
    }

    // move enemy in a direction based on a speed
    public void Move(Vector2 direction)
    {
        movementDirection = direction;
        body.velocity = new Vector2(direction.x * speed  * Time.deltaTime, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            movementDirection *= -1f;
        }
    }

}
