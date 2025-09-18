using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    private Vector2 _md = Vector2.zero;
    public Vector2 moveDir {
        get => _md; 
        private set {
            _md = value;
            if (value != shootDir && value != Vector2.zero)
            {
                shootDir = value.normalized;
            }
        } 
    }
    public Vector2 shootDir { get; private set; } = Vector2.left;
    float movementSpeed = 10.0f;
    float jumpForce = 8.0f;

    [SerializeField] bool isWalking = false;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isOnWall = false;

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
        SetMoveDirection();
        GroundCheck();
        WallCheck();
        if (Input.GetButtonDown("Jump")) //Key
        {
            Jump();
        }
        ApplyVelocity();
    }

    void SetMoveDirection()
    {
        //Get movement input
        moveDir = Vector2.zero;
        moveDir = new Vector2(
            Input.GetAxisRaw("Horizontal"), // x 1 or -1
            Input.GetAxisRaw("Vertical")  // y 1 or -1 Unused rn
            );
    }
    void GroundCheck()
    {
        //Check if grounded
        //If LayerMask does´nt work, try NameToLayer
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
        */

        //Other example directions
        //Vector2[] dirArray = { Vector2.up, new Vector2(1.0f, 1.0f), Vector2.right, Vector2.down, Vector2.left };
        Vector2[] dirArray = { Vector2.right, Vector2.left };
        foreach (Vector2 dir in dirArray)
        {
            RaycastHit2D hit2;
            Vector3 dirOffset = dir * 0.5f;
            hit2 = Physics2D.Raycast(transform.position + dirOffset, dir, 0.1f, LayerMask.GetMask("Ground")); //Non costly w infinite raycast
            Debug.DrawRay(transform.position + dirOffset, dir * 0.1f, Color.yellow);

            isOnWall = hit2.collider != null;

            if (isOnWall)
            {
                break;
            }
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void ApplyVelocity()
    {
        Vector2 velocity = Vector2.zero;
        velocity.x = moveDir.x * movementSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
