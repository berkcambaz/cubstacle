using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spin : ObstacleController
{
    public float speed;
    public Transform center;

    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, Time.deltaTime * speed);
    }
}
