using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public Camera cam;

    public LevelManager levelManager;

    void Awake()
    {
        Instance = this;

        InitManagers();

        LevelManager.StartLevel();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            LevelManager.StartLevel();
        }
    }

    private void InitManagers()
    {
        levelManager.Init();
    }
}
