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

        User.Load();
        LevelManager.StartLevel();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            LevelManager.StartLevel();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) User.Save();
    }

    private void InitManagers()
    {
        levelManager.Init();
    }
}
