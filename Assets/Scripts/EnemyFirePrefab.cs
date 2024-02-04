using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirePrefab : MonoBehaviour
{
    public enum FireType
    {
        Fireball,
        Arrow
    }

    public FireType fireType;
    private float movementSpeed;
    private Vector3 movementDirection;
    void Start()
    {

    }

    void Update()
    {
        SetPrefab(movementSpeed, movementDirection, fireType);
    }

    public void SetPrefab(float speed, Vector3 direction, FireType type)
    {
        fireType = type;
        movementSpeed = speed;
        movementDirection = direction;

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    public void SetRotation(Quaternion rotation)
    {

    }

}
