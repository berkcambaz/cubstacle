using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y + transform.localScale.y < -Utility.bounds.y)
        {
            Destroy(gameObject);
        }
    }
}
