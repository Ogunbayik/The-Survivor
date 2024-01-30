using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public enum EnemyType
    {
        Melee,
        Range
    }

    public string enemyName;
    public EnemyType type;
    [Header("Move Settings")]
    public float patrolDistance;
    public float patrolSpeed;
    public float chaseSpeed;
    public float rotateSpeed;
    public float chaseDistance;
    [Header("Attack Settings")]
    public float fireRate;
    public float attackDistance;
    [Header("General Settings")]
    public Color color;
    
}
