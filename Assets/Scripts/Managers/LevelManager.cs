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

    public void Init()
    {
        Instance = this;

        InitLevels();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            StartLevel();
        }
    }

    public static void StartLevel()
    {
        if (User.state != UserState.Menu) return;
        User.state = UserState.Playing;
        Instance.coroutineLevel = Instance.StartCoroutine(Instance.CoroutineLevel(Utility.GetLevelTime()));

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
        UI_Ingame.UpdateLevel();
        UI_Ingame.StopProgressBar();
    }

    private IEnumerator CoroutineLevel(float _time)
    {
        yield return new WaitForSeconds(_time);
        ++User.data.level;
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
