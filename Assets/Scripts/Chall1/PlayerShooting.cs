using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //TODO: CHECK 52.42, 1.03.10
    //TODO: 
    //TODO: Shoot Bullets Left or Right that Damage Enemies
    //TODO: Take Damage from Enemies
    //TODO: 
    //TODO: Enemyhit, oncollision or ontrigger
    //TODO: E: Damage Players on Touch
    //TODO: 
    //TODO: 
    //TODO: 
    //TODO: UI (User Interface) Showing Current Player Health or Score
    //TODO: A Game Over Screen
    //TODO: Om man har en prefabA i en prefabB och �ndrar den i A, �ndras det A i B ox�?
    //TODO: Vad beh�ver man g�ra om man flyttar saker till andra mappar?
    //TODO: Objektet i hierarkin, om det dras till prefab, �ndras bara objektet eller hela prefaben om man �ndrar p� objektet i hierarkin?
    
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
