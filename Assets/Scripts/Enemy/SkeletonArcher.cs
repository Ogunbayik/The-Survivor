using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : EnemyBase
{
    private enum ArcherType
    {
        Classic,
        Multiple,
        Area
    }
    private ArcherType type;
    private int typeCount = 3;

    [SerializeField] private Transform attackPoint;

    private float maxNextAttackTimer;
    private int maxArrowCount;
    private float nextAttackTimer;
    private float attackTimer;
    private int arrowCount;

    protected override void Initialize()
    {
        base.Initialize();

        attackTimer = enemySO.fireRate;
        nextAttackTimer = maxNextAttackTimer;
        arrowCount = 0;

        SetArcherType();
    }

    private void SetArcherType()
    {
        var randomTypeIndex = Random.Range(0, typeCount);
        switch(randomTypeIndex)
        {
            case 0:
                type = ArcherType.Classic;
                maxArrowCount = 1;
                maxNextAttackTimer = 3;
                break;
            case 1:
                type = ArcherType.Multiple;
                maxArrowCount = 3;
                maxNextAttackTimer = 4;
                break;
            case 2:
                type = ArcherType.Area;
                maxArrowCount = 3;
                maxNextAttackTimer = 3;
                break;
        }

     
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
        switch(type)
        {
            case ArcherType.Classic:
                ClassicAttack();
                break;
            case ArcherType.Multiple:
                MultipleAttack();
                break;
            case ArcherType.Area:
                break;
        }


        MultipleAttack();

        base.Attacking();
    }

    private void CreateArrow()
    {
        var arrow = Instantiate(enemySO.attackPrefab);
        arrow.transform.position = attackPoint.position;
        arrow.transform.rotation = transform.rotation;

        arrow.GetComponent<EnemyFirePrefab>().SetPrefab(enemySO.prefabSpeed, Vector3.forward, EnemyFirePrefab.FireType.Arrow);
    }
    private void ClassicAttack()
    {
        if (arrowCount < maxArrowCount)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                HandleRotation();
                attackTimer = enemySO.fireRate;
                arrowCount++;
                CreateArrow();
            }
        }
        else
        {
            nextAttackTimer -= Time.deltaTime;
            if (nextAttackTimer <= 0)
            {
                arrowCount = 0;
                nextAttackTimer = maxNextAttackTimer;
            }
        }
    }

    private void MultipleAttack()
    {
        if (arrowCount < maxArrowCount)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                HandleRotation();
                attackTimer = enemySO.fireRate;
                arrowCount++;
                CreateArrow();
            }
        }
        else
        {
            nextAttackTimer -= Time.deltaTime;
            if (nextAttackTimer <= 0)
            {
                arrowCount = 0;
                nextAttackTimer = maxNextAttackTimer;
            }
        }
    }

    private void HandleRotation()
    {
        transform.LookAt(player.transform.position);
    }

}
