using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] bool opensWithKey = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Something Entered");
        if(!opensWithKey)
        {
            return;
        }

        PlayerPickup pickup = collision.gameObject.GetComponent<PlayerPickup>();
        if (pickup != null)
        {
            if (pickup.keys > 0)
            {
                pickup.keys -= 1;
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        door.SetActive(false);
    }
    public void CloseDoor()
    {
        door.SetActive(true);
    }
}
