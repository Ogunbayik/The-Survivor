using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Debug.Log(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyPrefab = other.gameObject.GetComponent<EnemyFirePrefab>();

        var fireBallDamage = 10;
        var arrowDamage = 4;

        if (enemyPrefab)
        {
            if (enemyPrefab.fireType == EnemyFirePrefab.FireType.Fireball)
                DecreaseHealth(fireBallDamage);
            else if (enemyPrefab.fireType == EnemyFirePrefab.FireType.Arrow)
                DecreaseHealth(arrowDamage);

        }
            
    }

    private void DecreaseHealth(int health)
    {
        currentHealth -= health;
    }
}
