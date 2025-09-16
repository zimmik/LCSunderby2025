using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTimer : MonoBehaviour
{
    [SerializeField] Player[] players;
    [SerializeField] float timer = 0.0f;
    float maxTime = 2.0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            /*
            foreach (Player player in players)
            {
                player.Jump();
            }*/
            for(int i = 0; i < players.Length; i += 1)
            {
                players[i].Jump();
            }
            timer = 0.0f;
        }
    }
}
