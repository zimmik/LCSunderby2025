using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyDamage = 1;
    [SerializeField] Transform edgeCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] Transform groundCheck;
    [SerializeField] bool isGrounded = false;
    [SerializeField] Vector2 moveDir = Vector2.left;
    float movementSpeed = 4.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        GroundCheck();
        EdgeCheck();
        WallCheck();
        ApplyVelocity();
    }

    void EdgeCheck()
    {
        if (!isGrounded)
        {
            return;
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(edgeCheck.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
        Debug.DrawRay(edgeCheck.position, Vector2.down * 0.1f, Color.red);

        bool foundEdge = hit.collider == null;
        if (foundEdge)
        {
            //print("Found Edge");
            Vector3 newScale = transform.localScale;
            newScale.x *= -1.0f;
            moveDir.x *= -1.0f;

            transform.localScale = newScale;
        }
    }

    void WallCheck()
    {
        //Check if there's a wall in the enemy's move direction
        if (!isGrounded)
        {
            return;
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(wallCheck.position, moveDir, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
        Debug.DrawRay(wallCheck.position, moveDir * 0.1f, Color.red);

        if (hit.collider != null)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1.0f;
            moveDir *= -1.0f;
            transform.localScale = newScale;
        }
    }
    void GroundCheck()
    {
        // If LayerMask does´nt work, try NameToLayer
        bool touchingGround = rb.IsTouchingLayers(LayerMask.GetMask("Ground"));

        //Check if ground is down
        RaycastHit2D hit;
        hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.red);

        bool groundIsDown = hit.collider != null;

        isGrounded = touchingGround && groundIsDown;
    }

    void ApplyVelocity()
    {
        //Velocity applied last
        Vector2 velocity = Vector2.zero;
        //Vector2 dir = transform.TransformDirection(Vector2.left);
        velocity.x = moveDir.x * movementSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health targetHealth = collision.gameObject.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(enemyDamage);
                print("Bam");
            }
        }            
    }
}
