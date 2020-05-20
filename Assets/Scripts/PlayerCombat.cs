using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform meleePoint;
    public float meleeRange = 0.5f;
    public int meleeDamage = 10;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Melee"))
        {
            Melee();
        }
    }

    void Melee()
    {
        animator.SetTrigger("melee");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<NPCEnemy>().TakeDamage(meleeDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
    }
}
