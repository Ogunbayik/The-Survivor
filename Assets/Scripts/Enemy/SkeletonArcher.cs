using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : EnemyBase
{
    [SerializeField] private Transform attackPoint;

    protected override void Initialize()
    {
        base.Initialize();
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
        base.Attacking();
    }

    private void CreateArrow()
    {
        var arrow = Instantiate(enemySO.attackPrefab);
        arrow.transform.position = attackPoint.position;
        arrow.transform.rotation = transform.rotation;

    }

}
