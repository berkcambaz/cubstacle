using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform endPoint;

    public float speed;
    private bool spawnedAnotherLevel = false;

    void Update()
    {
        if (!spawnedAnotherLevel && endPoint.position.y < 0f)
        {
            spawnedAnotherLevel = true;
            LevelManager.SpawnRandomLevel();
        }

        if (endPoint.position.y < -Utility.bounds.y)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
