using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamage = 1;
    float bulletSpeed = 20.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // rb.velocity = Vector2.up * bulletSpeed;
       // rb.velocity = Vector2.right * bulletSpeed;
        rb.velocity = Vector2.left * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(bulletDamage);
            print("Pow");
        }
        Destroy(gameObject); //Destroy the bullet itself
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
