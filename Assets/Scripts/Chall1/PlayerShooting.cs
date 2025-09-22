using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //TODO: CHECK 52.42, 1.03.10
    //TODO: 
    //TODO: 
    //TODO: Take Damage from Enemies
    //TODO: 
    //TODO: Enemyhit, oncollision or ontrigger
    //TODO: 
    //TODO: 
    //TODO: Om man har en prefabA i en prefabB och �ndrar den i A, �ndras det A i B ox�?
    //TODO: Vad beh�ver man g�ra om man flyttar saker till andra mappar?
    //TODO: Objektet i hierarkin, om det dras till prefab, �ndras bara objektet eller hela prefaben om man �ndrar p� objektet i hierarkin?
    
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    float spawnOffset = 1.5f;

    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        Vector2 dir = player.shootDir;
        if (dir != Vector2.zero) 
        {
            Vector2 point = dir.normalized * spawnOffset;
            bulletSpawnPoint.localPosition = (point);
        }
        Shoot(dir);
    }

    void Shoot(Vector2 dir)
    {
        if(Input.GetKeyDown(KeyCode.E)) //TODO: input
        {
            print("Pew"); 
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Bullet b = bullet.GetComponent<Bullet>();
            b.SetDirection(dir); //b.Direction = dir;
            b.Fire();
        }
    }
}
