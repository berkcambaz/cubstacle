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
    public int score = 0;
    public int highscore = 0;
    public int level = 1;
    public int gold = 0;
}

public enum UserState
{
    Menu,
    Playing,
    Ending,
    Paused
}