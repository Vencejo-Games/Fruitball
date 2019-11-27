using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitball : MonoBehaviour
{
    private float speed = 10f;

    //private Rigidbody2D body;
    private bool movementDirection;

    // Update is called once per frame
    void Update()
    {
        Move(movementDirection);
    }

    // move enemy in a direction based on a speed
    public void Move(bool direction)
    {
        movementDirection = direction;
        float currentSpeed = direction ? speed : (speed * -1f);
        transform.position = new Vector3(transform.position.x + currentSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

}
