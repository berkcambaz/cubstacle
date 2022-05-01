using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject prefabPlayer;
    private GameObject[] prefabLevels;

    private GameObject player;
    private List<GameObject> levels = new List<GameObject>();

    public void Init()
    {
        Instance = this;

        InitLevels();
    }

    public static void StartLevel()
    {
        if (User.playing) return;
        User.playing = true;

        SpawnPlayer();
        SpawnRandomLevel();
    }

    public static void StopLevel()
    {
        User.playing = false;

        DespawnPlayer();
        DespawnLevels();
    }

    public static void Progress()
    {
        SpawnRandomLevel();
    }

    private static void SpawnPlayer()
    {
        Instance.player = Instantiate(Instance.prefabPlayer);
    }

    private static void SpawnRandomLevel()
    {
        Instance.levels.Add(Instantiate(Instance.prefabLevels[0]));
    }

    private static void DespawnPlayer()
    {
        Destroy(Instance.player);
    }

    private static void DespawnLevels()
    {
        for (int i = 0; i < Instance.levels.Count; ++i)
        {
            Destroy(Instance.levels[i]);
        }
    }

    private void InitLevels()
    {
        prefabLevels = Resources.LoadAll<GameObject>("Prefabs/Levels");
    }
}
