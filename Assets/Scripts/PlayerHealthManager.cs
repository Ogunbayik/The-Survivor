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
        var fireball = other.gameObject.GetComponent<Fireball>();
        var fireBallDamage = 2;

        if (fireball)
            DecreaseHealth(fireBallDamage);
    }

    private void DecreaseHealth(int health)
    {
        currentHealth -= health;
    }
}
