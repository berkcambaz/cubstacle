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
    }

    private void InitManagers()
    {
        levelManager.Init();
    }
}
