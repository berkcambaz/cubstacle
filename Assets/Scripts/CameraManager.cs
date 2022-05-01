using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Camera cam;
    [SerializeField] private GameObject[] blackbars;

    public void Init()
    {
        Instance = this;

        ConfigAspect();
    }

    private void ConfigAspect()
    {
        float ortho = cam.orthographicSize;
        Vector2 target = new Vector2(1080f, 1920f);

        if (Screen.width > Screen.height)
        {
            Vector2 current = new Vector2(Screen.height, Screen.width);
            float dt = ortho * (target.x / target.y);
            cam.orthographicSize = dt / (current.x / current.y);

            float width = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;

            GameObject bar0 = blackbars[(int)Utility.Direction.Left];
            GameObject bar1 = blackbars[(int)Utility.Direction.Right];

            bar0.transform.position = new Vector3(-Utility.bounds.x, 0f, bar0.transform.position.z);
            bar1.transform.position = new Vector3(Utility.bounds.x, 0f, bar1.transform.position.z);

            bar0.transform.localScale = new Vector3((width - Utility.bounds.x), Utility.bounds.y * 2, 1f);
            bar1.transform.localScale = new Vector3((width - Utility.bounds.x), Utility.bounds.y * 2, 1f);

            bar0.SetActive(true);
            bar1.SetActive(true);
        }
        else
        {
            Vector2 current = new Vector2(Screen.width, Screen.height);
            float dt = ortho * (target.x / target.y);
            cam.orthographicSize = dt / (current.x / current.y);

            float height = cam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;

            GameObject bar0 = blackbars[(int)Utility.Direction.Top];
            GameObject bar1 = blackbars[(int)Utility.Direction.Bottom];

            bar0.transform.position = new Vector3(0f, Utility.bounds.y, bar0.transform.position.z);
            bar1.transform.position = new Vector3(0f, -Utility.bounds.y, bar1.transform.position.z);

            bar0.transform.localScale = new Vector3(Utility.bounds.x * 2, (height - Utility.bounds.y), 1f);
            bar1.transform.localScale = new Vector3(Utility.bounds.x * 2, (height - Utility.bounds.y), 1f);

            bar0.SetActive(true);
            bar1.SetActive(true);
        }
    }
}
