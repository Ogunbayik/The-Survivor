using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private enum States
    {
        Patrol,
        Chase,
        Attack
    }
    private States currentState;

    [SerializeField] protected EnemySO enemySO;

    protected PlayerController player;
    protected float distanceBetweenPlayer;
    protected float maximumBorderX;
    protected float minimumBorderX;
    protected float maximumBorderZ;
    protected float minimumBorderZ;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        currentState = States.Patrol;

        maximumBorderX = transform.localPosition.x + enemySO.patrolDistance;
        maximumBorderZ = transform.localPosition.z + enemySO.patrolDistance;
        minimumBorderX = transform.localPosition.x - enemySO.patrolDistance;
        minimumBorderZ = transform.localPosition.z - enemySO.patrolDistance;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case States.Patrol:
                Patrolling();
                break;
            case States.Chase:
                Chasing();
                break;
            case States.Attack:
                Attacking();
                break;
        }
    }

    protected virtual void Patrolling()
    {
        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetweenPlayer <= enemySO.chaseDistance)
            currentState = States.Chase;
    }

    protected virtual void Chasing()
    {
        Debug.Log("Chasing");
        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetweenPlayer >= enemySO.chaseDistance)
            currentState = States.Patrol;

        if (distanceBetweenPlayer <= enemySO.attackDistance && enemySO.type != EnemySO.EnemyType.Melee)
            currentState = States.Attack;

    }

    protected virtual void Attacking()
    {
        Debug.Log("Attacking");

        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        var attackOutOfRange = enemySO.attackDistance + 2f;

        if (attackOutOfRange <= distanceBetweenPlayer)
            currentState = States.Chase;
        
    }

    protected virtual void HandleMovement()
    {
        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetweenPlayer < enemySO.chaseDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySO.chaseSpeed * Time.deltaTime);
        }
    }
}
