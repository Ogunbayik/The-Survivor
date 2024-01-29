using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyBase
{
    private bool isRight = true;

    private Vector3 desiredPosition;
    protected override void HandleMovement()
    {
        base.HandleMovement();
    }

    protected override void Patrolling()
    {
        if (isRight)
        {
            desiredPosition = new Vector3(maximumBorderX, 0f, 0f);
        }
        else
        {
            desiredPosition = new Vector3(-minimumBorderX, 0f, 0f);
        }

        var distanceBetweenDesiredPosition = Vector3.Distance(transform.position, desiredPosition);
        if (distanceBetweenDesiredPosition <= 0.1f)
        {
            isRight = !isRight;
        }

        transform.Translate(desiredPosition * enemySO.patrolSpeed * Time.deltaTime);

        base.Patrolling();
    }
}
