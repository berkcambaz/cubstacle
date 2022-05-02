using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkinMenu : MonoBehaviour
{
    public static UI_SkinMenu Instance;

    public Skin[] skins;

    public void Init()
    {
        Instance = this;
    }
}
