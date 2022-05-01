using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public static SaveData data = new SaveData();
    public static UserState state = UserState.Menu;

    public static void Save()
    {
        try
        {
            string json = JsonUtility.ToJson(data);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/user.save", json);
        }
        catch (System.Exception _e)
        {
            Debug.Log(_e);
        }
    }

    public static void Load()
    {
        try
        {
            string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/user.save");
            data = JsonUtility.FromJson<SaveData>(json);

            UI_Ingame.UpdateScore();
            UI_Ingame.UpdateLevel();
        }
        catch (System.Exception _e)
        {
            Debug.Log(_e);
            Save();
        }
    }
}

[System.Serializable]
public class SaveData
{
    [SerializeField] private int m_score = 0;
    public int score
    {
        get { return m_score; }
        set
        {
            m_score = value;
            if (m_score > highscore) highscore = m_score;
            UI_Ingame.UpdateScore();
        }
    }

    public int highscore = 0;

    [SerializeField] private int m_level = 1;
    public int level
    {
        get { return m_level; }
        set
        {
            m_level = value;
            UI_Ingame.UpdateLevel();
        }
    }

    public int gold = 0;
}

public enum UserState
{
    Menu,
    Playing,
    Ending,
    Paused
}