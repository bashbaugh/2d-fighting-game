using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public int maxHealth = 50;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("die");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
