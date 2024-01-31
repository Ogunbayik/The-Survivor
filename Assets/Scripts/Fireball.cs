using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float movementSpeed;
    private Vector3 movementDirection;
    void Start()
    {
        
    }

    void Update()
    {
        Movement(movementSpeed, movementDirection);
    }

    public void Movement(float speed, Vector3 direction)
    {
        movementSpeed = speed;
        movementDirection = direction;

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}
