using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirbScript : MonoBehaviour
{
    public Rigidbody2D birbRigidbody;
    public float flapStrength = 20;
    public LogicScript logic;
    public bool birbIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birbIsAlive) //TODO: Fix input to more versatile
        { 
            birbRigidbody.velocity = Vector2.up * flapStrength; //Time.deltaTime not needed bc physics runs on its own clock
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birbIsAlive = false;
    }
}
