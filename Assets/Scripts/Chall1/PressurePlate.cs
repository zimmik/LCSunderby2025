using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    //[SerializeField] LockedDoor door;
    [SerializeField] UnityEvent platePressed;
    [SerializeField] UnityEvent plateUnpressed;
    [SerializeField] bool keepPressed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            platePressed.Invoke();
        //door.OpenDoor();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (keepPressed)
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            plateUnpressed.Invoke();
            //door.CloseDoor();
        }
    }
}
