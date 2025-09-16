using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform edgeCheck;
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
            print("Found Edge");
            Vector3 newScale = transform.localScale;
            newScale.x *= -1.0f;
            moveDir.x *= -1.0f;

            transform.localScale = newScale;
        }
    }

    /*
    void WallCheck()
    {
        if (!isGrounded)
        {
            return;
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(edgeCheck.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.red);

        bool foundEdge = hit.collider == null;
        if (foundEdge && isGrounded)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1.0f;
           // inputDir *= -1.0f;
            transform.localScale = newScale;
        }
    }*/
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

    public void WallCheck()
    {
        //Check if ground on wall
        //Vector2.right; // x1, y0
        /*
        float[] dirArray = { 1.0f, -1.0f };
        foreach (float dir in dirArray)
        {
            RaycastHit2D hit2;
            Vector3 rightOffset = Vector2.right * 0.5f * dir;
            hit2 = Physics2D.Raycast(transform.position + rightOffset, Vector2.right * dir, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
            Debug.DrawRay(transform.position + rightOffset, Vector2.right * dir * 0.1f, Color.yellow);

            isOnWall = hit2.collider != null;

            if (isOnWall)
            {
                break;
            }
        }

        float[] dirArray = { 1.0f, -1.0f };
        foreach (float dir in dirArray)
        {
            RaycastHit2D hit2;
            Vector3 dirOffset = dir * 0.5f;
            hit2 = Physics2D.Raycast(transform.position + dirOffset, Vector2.right * dir, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
            Debug.DrawRay(transform.position + dirOffset, Vector2.right * dir * 0.1f, Color.yellow);

            isOnWall = hit2.collider != null;

            if (isOnWall)
            {
                break;
            }
        }
        */
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
}
