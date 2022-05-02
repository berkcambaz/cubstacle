using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menus : MonoBehaviour
{
    public static UI_Menus Instance;

    public UI_SkinMenu uiSkinMenu;

    public Text textMenuName;
    public Button buttonNext;
    public Button buttonPrevious;

    private UIMenu state = UIMenu.Skins;

    public void Init()
    {
        Instance = this;

        uiSkinMenu.Init();

        buttonNext.onClick.AddListener(NextMenu);
        buttonPrevious.onClick.AddListener(PreviousMenu);
    }

    public static void NextMenu()
    {
        int index = (int)Instance.state + 1;
        if (index >= (int)UIMenu.Count) index = 0;
        SetMenu((UIMenu)index);
    }

    public static void PreviousMenu()
    {
        int index = (int)Instance.state - 1;
        if (index < 0) index = (int)UIMenu.Count - 1;
        SetMenu((UIMenu)index);
    }

    public static void SetMenu(UIMenu _menu)
    {
        Instance.state = _menu;

        switch (_menu)
        {
            case UIMenu.Skins:
                Instance.textMenuName.text = "skins";
                break;
            case UIMenu.Chest:
                Instance.textMenuName.text = "chest";
                break;
            case UIMenu.Achievements:
                Instance.textMenuName.text = "achievements";
                break;
        }
    }
}

public enum UIMenu
{
    Skins,
    Chest,
    Achievements,
    Count
}