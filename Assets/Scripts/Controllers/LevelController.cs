using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform endPoint;

    public float speed;
    public bool flippable;
    private bool spawnedAnotherLevel = false;

    void OnEnable()
    {
        if (flippable && LevelManager.Instance.srandom.Boolean())
        {
            Vector3 scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        if (!spawnedAnotherLevel && endPoint.position.y < 0f)
        {
            spawnedAnotherLevel = true;
            LevelManager.Progress();
        }

        if (endPoint.position.y < -Utility.bounds.y)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
