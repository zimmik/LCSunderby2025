using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.U2D;

public class Movement : MonoBehaviour
{
    Vector2 moveDir;
    float movementSpeed = 8f;
    [SerializeField] bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) // UP
        {
            moveDir.y += 1.0f;
        }
        if (Input.GetKey(KeyCode.A)) // UP
        {
            moveDir.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.S)) // UP
        {
            moveDir.y -= 1.0f;
        }
        if (Input.GetKey(KeyCode.D)) // UP
        {
            moveDir.x += 1.0f;
        }
        //moveDir = new Vector2(Input.GetAxisRaw("Horisontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveDir * Time.deltaTime * movementSpeed);
    }
}
