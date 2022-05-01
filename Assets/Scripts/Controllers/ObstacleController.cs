using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private bool scored = false;

    void Update()
    {
        if (!scored && transform.position.y + transform.localScale.y / 2f < LevelManager.GetPlayer().transform.position.y)
        {
            scored = true;
            User.data.score++;
        }

        if (transform.position.y + transform.localScale.y < -Utility.bounds.y)
        {
            Destroy(gameObject);
        }
    }
}
