using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UI_Ingame uiIngame;
    public UI_Menus uiMenus;

    public void Init()
    {
        Instance = this;

        InitUIs();
    }

    private void InitUIs()
    {
        uiIngame.Init();
        uiMenus.Init();
    }
}
