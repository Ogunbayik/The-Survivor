using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemySO enemySO;

    protected PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySO.movementSpeed * Time.deltaTime);
    }
}
