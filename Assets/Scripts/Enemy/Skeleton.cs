using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemyBase
{
    private int randomIndex;
    private bool isChange = true;

    private Vector3 desiredPosition;
    private Vector3 firstPosition;
    private Vector3 secondPosition;

    protected override void Initialize()
    {
        base.Initialize();
        randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            //GOING X AXIS
            firstPosition = transform.position + new Vector3(enemySO.patrolDistance, 0f, 0f);
            secondPosition = transform.position + new Vector3(-enemySO.patrolDistance, 0f, 0f);
        }
        else if (randomIndex == 1)
        {
            //GOING Z AXIS
            firstPosition = transform.position + new Vector3(0f, 0f, enemySO.patrolDistance);
            secondPosition = transform.position + new Vector3(0f, 0f, -enemySO.patrolDistance);
        }

        desiredPosition = firstPosition;
    }

    protected override void Patrolling()
    {
        var movementStep = enemySO.patrolSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, movementStep);

        if (Vector3.Distance(transform.position, desiredPosition) <= 0.1f)
        {
            isChange = !isChange;
            GetDesiredPosition();
        }

        base.Patrolling();
    }

    private Vector3 GetDesiredPosition()
    {
        if (isChange)
            desiredPosition = firstPosition;
        else
            desiredPosition = secondPosition;

        return desiredPosition;
    }
}
