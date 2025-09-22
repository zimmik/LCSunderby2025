using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcher : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject enteringObject = collision.gameObject;
        if (enteringObject.tag == "Player")
        {
            enteringObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject exitingObject = collision.gameObject;
        if (exitingObject.tag == "Player")
        {
            exitingObject.transform.parent = null;
        }
    }
}
