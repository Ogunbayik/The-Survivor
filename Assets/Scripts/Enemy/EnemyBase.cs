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

    protected MeshRenderer meshRenderer;
    protected PlayerController player;
    protected float distanceBetweenPlayer;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        currentState = States.Patrol;
        meshRenderer.material.color = enemySO.color;
    }

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
        ChasePlayer();

        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetweenPlayer >= enemySO.chaseDistance)
            currentState = States.Patrol;

        if (distanceBetweenPlayer <= enemySO.attackDistance && enemySO.type != EnemySO.EnemyType.Melee)
            currentState = States.Attack;

    }
    private void ChasePlayer()
    {
        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetweenPlayer < enemySO.chaseDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySO.chaseSpeed * Time.deltaTime);
        }
    }

    protected virtual void Attacking()
    {
        Debug.Log("Attacking");

        distanceBetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        var attackOutOfRange = enemySO.attackDistance + 2f;

        if (attackOutOfRange <= distanceBetweenPlayer)
            currentState = States.Chase;
        
    }
}
