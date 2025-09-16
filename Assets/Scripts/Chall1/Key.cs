using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPickup pickup = collision.gameObject.GetComponent<PlayerPickup>();
        if (pickup != null)
        {
            pickup.keys += 1;
            Destroy(gameObject);
        }
    }
}
