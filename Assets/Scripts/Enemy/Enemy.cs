using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f;
    public ParticleSystem ps;
    public Animator animator;
    public int maxHealth = 100;
    public float attackRange = 3f;
    public float deathJumpForce = 50f;
    private int currentHealth;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ps.Emit(40);

        animator.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        
        rb.AddForce(new Vector2(0f, deathJumpForce));
        
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = true;
    }
}
