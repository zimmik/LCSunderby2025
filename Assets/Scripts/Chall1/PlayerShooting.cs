using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //TODO: CHECK 52.42, 1.03.10
    //TODO: Wall
    //TODO: Shoot Bullets Left or Right that Damage Enemies
    //TODO: Take Damage from Enemies
    //TODO: Collect Items
    //TODO: Enemyhit, oncollision or ontrigger
    //TODO: E: Damage Players on Touch
    //TODO: A Door that is opened with the Key Item
    //TODO: A Door that is opened with the Key Item
    //TODO: A Door that is opened with the pressure plate (it may stay open)
    //TODO: UI (User Interface) Showing Current Player Health or Score
    //TODO: A Game Over Screen
    //TODO: Om man har en prefabA i en prefabB och ändrar den i A, ändras det A i B oxå?
    //TODO: Vad behöver man göra om man flyttar saker till andra mappar?
    //TODO: Objektet i hierarkin, om det dras till prefab, ändras bara objektet eller hela prefaben om man ändrar på objektet i hierarkin?
    
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
