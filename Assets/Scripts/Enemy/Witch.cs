using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : EnemyBase
{
    private enum CoordinateType
    {
        positiveX,
        negativeX,
        positiveZ,
        negativeZ
    }
    private CoordinateType coordinates;

    [Header("Teleport Settings")]
    [SerializeField] private float startTeleportTimer;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    private float randomX;
    private float randomZ;

    [SerializeField] private Transform attackPoint;
    private Vector3 teleportPoint;
    private float teleportTimer;
    
    
    protected override void Initialize()
    {
        base.Initialize();

        teleportTimer = startTeleportTimer;
        transform.position = GetRandomTeleportPoint();
        HandleRotation();
    }

    protected override void Patrolling()
    {
        base.Patrolling();
    }

    protected override void Chasing()
    {
        base.Chasing();
    }

    protected override void Attacking()
    {
        teleportTimer -= Time.deltaTime;

        if(teleportTimer <= 0)
        {
            teleportTimer = startTeleportTimer;
            transform.position = GetRandomTeleportPoint();
            HandleRotation();
            CreateFireball();
        }


        base.Attacking();
    }

    private void CreateFireball()
    {
        var fireball = Instantiate(enemySO.attackPrefab);
        fireball.transform.position = attackPoint.position;
        fireball.transform.rotation = transform.rotation;
        fireball.GetComponent<Fireball>().Movement(enemySO.prefabSpeed, Vector3.forward);
    }

    private Vector3 GetRandomTeleportPoint()
    {
        if (xRange > zRange)
        {
            if (teleportPoint.x >= 0)
                coordinates = CoordinateType.positiveX;
            else
                coordinates = CoordinateType.negativeX;
        }
        else
        {
            if (teleportPoint.z >= 0)
                coordinates = CoordinateType.positiveZ;
            else
                coordinates = CoordinateType.negativeZ;
        }

        switch(coordinates)
        {
            case CoordinateType.positiveX:
                //Change Negative Coordinate X
                randomX = Random.Range(-xRange, 0);
                randomZ = Random.Range(-zRange, zRange);
                break;
            case CoordinateType.negativeX:
                //Change Positive Coordinate X
                randomX = Random.Range(0, xRange);
                randomZ = Random.Range(-zRange, zRange);
                break;
            case CoordinateType.positiveZ:
                //Change Negative Coordinate Z
                randomX = Random.Range(-xRange, xRange);
                randomZ = Random.Range(-zRange, 0);
                break;
            case CoordinateType.negativeZ:
                //Change Positive Coordinate Z
                randomX = Random.Range(-xRange, xRange);
                randomZ = Random.Range(0, zRange);
                break;
        }    
        var posY = 0f;

        teleportPoint = new Vector3(randomX, posY, randomZ);
        return teleportPoint;
    }

    private void HandleRotation()
    {
        transform.LookAt(player.transform.position, Vector3.up);
    }
}
