using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRange = 6f;
    public int explosionDamage = 50;
    public LayerMask enemyLayers;
    public ParticleSystem explosionParticleSystem;
    
    private float bombExplosionTime;
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        bombExplosionTime = Time.time + 4f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        explosionParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= bombExplosionTime)
        {
            Explode();
        }
    }

    void Explode()
    {
        explosionParticleSystem.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rb.position, explosionRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(explosionDamage);
        }

        sr.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(rb.position, explosionRange);
    }
}
