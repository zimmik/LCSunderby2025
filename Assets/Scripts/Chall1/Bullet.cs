using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamage = 1;
    //[SerializeField]
    Vector2 direction;
    
    float bulletSpeed = 20.0f;
    Rigidbody2D rb;

    //       public Vector2 Direction { get => direction; set => direction = value.normalized; }
    // alt.  public Vector2 Direction { get => direction; set { direction = value.normalized; } }
    // alt.  public Vector2 Direction { get { return direction; } set { direction = value.normalized; } }

    public void SetDirection(Vector2 dir)
    {

        print("set dir ");
        direction = dir.normalized;
    }
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    public void Fire()
    {
        rb = GetComponent<Rigidbody2D>();
        print("burn ");
        // rb.velocity = Vector2.up * bulletSpeed;
        // rb.velocity = Vector2.right * bulletSpeed;
        //rb.velocity = Vector2.left * bulletSpeed;
        if (direction == null)
        {
            print("null " );
            direction = Vector2.up;
        }
        rb.velocity = direction * bulletSpeed;
        print("vel " + rb.velocity + "   dir " + direction + "   bull " + bulletSpeed);
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
