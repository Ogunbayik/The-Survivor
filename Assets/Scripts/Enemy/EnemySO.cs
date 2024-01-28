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

    public EnemyType type;
    public string enemyName;
    public float movementSpeed;
    public float rotateSpeed;
    public float fireRate;
}
