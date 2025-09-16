using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoingPlatform : MonoBehaviour
{
    [SerializeField] float maxTime = 2.0f;
    [SerializeField] Transform startPoint, endPoint, platform;
    float timer = 0.0f;
    float timerDir = 1.0f;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        timer += Time.deltaTime * timerDir;
        platform.position = Vector2.Lerp(startPoint.position, endPoint.position, (timer / maxTime));  //0-1 Ratio
        if (timer >= maxTime && timerDir == 1.0f)
        {
            timerDir = -1.0f;
        }
        if (timer <= 0.0 && timerDir == -1.0f)
        {
            timerDir = 1.0f;
        }
    }
}
