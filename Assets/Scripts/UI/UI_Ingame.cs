using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ingame : MonoBehaviour
{
    public static UI_Ingame Instance;

    public Text textScore;
    public Text textHighscore;
    public Text textLevel;
    public RectTransform rectProgress;
    public GameObject buttonStart;
    public GameObject buttonContinue;
    public Button buttonPause;

    private Coroutine coroutineProgressBar;

    public void Init()
    {
        Instance = this;

        buttonPause.onClick.AddListener(ButtonPause);
    }

    public static void UpdateScore()
    {
        Instance.textScore.text = User.data.score.ToString();
        Instance.textHighscore.text = $"highscore: {User.data.highscore}";
    }

    public static void UpdateLevel()
    {
        Instance.textLevel.text = $"level {User.data.level}";
    }

    public static void OnUserStateChange()
    {
        switch (User.state)
        {
            case UserState.Menu:
                Instance.buttonStart.SetActive(true);
                Instance.buttonContinue.SetActive(false);
                Instance.buttonPause.gameObject.SetActive(false);
                break;
            case UserState.Playing:
                Instance.buttonStart.SetActive(false);
                Instance.buttonContinue.SetActive(false);
                Instance.buttonPause.gameObject.SetActive(true);
                break;
            case UserState.Paused:
                Instance.buttonStart.SetActive(false);
                Instance.buttonContinue.SetActive(true);
                Instance.buttonPause.gameObject.SetActive(false);
                break;
            case UserState.Ending:
                Instance.buttonStart.SetActive(false);
                Instance.buttonContinue.SetActive(false);
                Instance.buttonPause.gameObject.SetActive(false);
                break;
        }
    }

    public static void StartProgressBar(float _time)
    {
        Instance.coroutineProgressBar = Instance.StartCoroutine(Instance.StartProgress(_time));
    }

    public static void StopProgressBar()
    {
        Instance.StopCoroutine(Instance.coroutineProgressBar);
        Instance.StartCoroutine(Instance.StopProgress());
    }

    private IEnumerator StartProgress(float _time)
    {
        Vector3 current = rectProgress.localScale;
        Vector3 target = new Vector3(1f, 1f, 1f);

        float currentTime = 0;
        float normalizedValue = 0;
        while (true)
        {
            if (currentTime > _time) break;

            if (User.state == UserState.Playing)
            {
                currentTime += Time.deltaTime;
                normalizedValue = currentTime / _time;
                rectProgress.localScale = Vector3.Lerp(current, target, normalizedValue);
            }
            yield return null;
        }
    }

    private IEnumerator StopProgress()
    {
        Vector3 current = rectProgress.localScale;
        Vector3 target = new Vector3(0f, 1f, 1f);

        float currentTime = 0;
        float normalizedValue = 0;

        while (currentTime <= current.x / 2f)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / (current.x / 2f);
            rectProgress.localScale = Vector3.Lerp(current, target, normalizedValue);
            yield return null;
        }

        User.state = UserState.Menu;
    }

    private void ButtonPause()
    {
        LevelManager.SuspendLevel();
    }
}
