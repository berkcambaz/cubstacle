using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject prefabPlayer;
    private GameObject[] prefabLevels;

    private GameObject player;
    private List<GameObject> levels = new List<GameObject>();
    private Coroutine coroutineLevel;
    public SeedRandom srandom;

    public void Init()
    {
        Instance = this;

        InitLevels();
    }

    void Update()
    {
        bool click = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

        switch (User.state)
        {
            case UserState.Menu:
                if (click) StartLevel();
                break;
            case UserState.Playing:
                break;
            case UserState.Paused:
                if (click) ContinueLevel();
                break;
            case UserState.Ending:
                break;
        }
    }

    public static void StartLevel()
    {
        if (User.state != UserState.Menu) return;
        User.state = UserState.Playing;
        Instance.coroutineLevel = Instance.StartCoroutine(Instance.CoroutineLevel(Utility.GetLevelTime()));
        Instance.srandom = new SeedRandom(User.data.level);

        SpawnPlayer();
        SpawnRandomLevel();
        UI_Ingame.StartProgressBar(Utility.GetLevelTime());
    }

    public static void StopLevel()
    {
        if (User.state != UserState.Playing) return;
        User.state = UserState.Ending;
        Instance.StopCoroutine(Instance.coroutineLevel);

        DespawnPlayer();
        DespawnLevels();
        UI_Ingame.StopProgressBar();
    }

    public static void SuspendLevel()
    {
        if (User.state != UserState.Playing) return;
        User.state = UserState.Paused;
        Time.timeScale = 0f;
    }

    public static void ContinueLevel()
    {
        if (User.state != UserState.Paused) return;
        User.state = UserState.Playing;
        Time.timeScale = 1f;
    }

    private IEnumerator CoroutineLevel(float _time)
    {
        yield return new WaitForSeconds(_time);
        User.data.level++;
        StopLevel();
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
        int index = Instance.srandom.Number(0, Instance.prefabLevels.Length);
        Instance.levels.Add(Instantiate(Instance.prefabLevels[index]));
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

    public static GameObject GetPlayer()
    {
        return Instance.player;
    }

    private void InitLevels()
    {
        prefabLevels = Resources.LoadAll<GameObject>("Prefabs/Levels");
    }
}
