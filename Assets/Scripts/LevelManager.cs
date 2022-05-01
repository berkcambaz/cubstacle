using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject prefabPlayer;
    private GameObject[] prefabLevels;

    private GameObject player;
    private List<GameObject> levels;

    public void Init()
    {
        Instance = this;

        InitLevels();
    }

    public static void StartLevel()
    {
        SpawnPlayer();
        SpawnRandomLevel();
    }

    public static void StopLevel()
    {

    }

    public static void SpawnPlayer()
    {
        Instance.player = Instantiate(Instance.prefabPlayer);
    }

    public static void SpawnRandomLevel()
    {
        Instance.levels.Add(Instantiate(Instance.prefabLevels[0]));
    }

    private void InitLevels()
    {
        prefabLevels = Resources.LoadAll<GameObject>("Prefabs/Levels");
    }
}
