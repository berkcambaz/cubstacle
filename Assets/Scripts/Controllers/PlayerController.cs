using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    private bool dragging = false;
    private Vector2 dragPos;

    void Update()
    {
        GetInput();
        ClampToBounds();
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
        ObstacleController obstacle = _collision.transform.GetComponent<ObstacleController>();
        if (obstacle)
        {
            User.data.score = 0;
            LevelManager.StopLevel();
        }
    }

    private void GetInput()
    {
        GetInputMouse();
        GetInputTouch();
    }

    private void GetInputMouse()
    {
        if (!Input.GetMouseButton(0))
        {
            dragging = false;
            return;
        }

        if (dragging)
        {
            Vector2 mousePos = CameraManager.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offest = mousePos - dragPos;
            transform.Translate(offest);
            dragPos = CameraManager.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            dragging = true;
            dragPos = CameraManager.Instance.cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void GetInputTouch()
    {

    }

    private void ClampToBounds()
    {
        Vector2 size = new Vector2(transform.localScale.x, transform.localScale.y);
        float x = Mathf.Clamp(transform.position.x, -Utility.bounds.x + size.x / 2f, Utility.bounds.x - size.x / 2f);
        float y = Mathf.Clamp(transform.position.y, -Utility.bounds.y + size.y / 2f, Utility.bounds.y - size.y / 2f);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
