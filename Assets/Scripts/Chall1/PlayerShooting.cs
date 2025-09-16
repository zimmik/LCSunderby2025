using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //TODO: CHECK 52.42, 1.03.10
    //TODO: Wall
    //TODO: Enemyhit, oncollision or ontrigger
    //TODO: Vad behöver man göra om man flyttar saker till andra mappar?
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.E)) //TODO key
        {
            print("Pew");
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
