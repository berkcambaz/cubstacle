using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private GameObject[] prefabLevels;

    public void Init()
    {
        Instance = this;

        InitLevels();

        SpawnRandomLevel();
    }

    public static void SpawnRandomLevel()
    {
        Instantiate(Instance.prefabLevels[0]);
    }

    private void InitLevels()
    {
        prefabLevels = Resources.LoadAll<GameObject>("Prefabs/Levels");
    }
}
