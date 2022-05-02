using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public GameObject objectLock;

    public void SetLock(bool _lock)
    {
        objectLock.SetActive(!_lock);
    }
}
