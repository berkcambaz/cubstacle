using UnityEngine;

public class Utility
{
    public enum Direction : int
    {
        Top,
        Right,
        Bottom,
        Left
    }

    public static Vector2 bounds = new Vector2(4.5f, 8f);

    public static float GetLevelTime()
    {
        return 15f + Mathf.Clamp((User.data.level - 1) * 0.1f, 0f, 25f);
    }
}
