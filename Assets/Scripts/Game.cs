using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public UIManager uiManager;
    public CameraManager cameraManager;
    public LevelManager levelManager;

    void Awake()
    {
        Instance = this;

        InitManagers();

        User.Load();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) User.Save();
    }

    private void InitManagers()
    {
        uiManager.Init();
        cameraManager.Init();
        levelManager.Init();
    }
}
