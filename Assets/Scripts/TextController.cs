using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public float time;
    public float angle;
    private Coroutine coroutineRotate;

    void OnEnable()
    {
        coroutineRotate = StartCoroutine(Rotate(time, angle));
    }

    void OnDisable()
    {
        StopCoroutine(coroutineRotate);
    }

    private IEnumerator Rotate(float _time, float _rot)
    {
        float current = transform.rotation.eulerAngles.z;
        float target = _rot;

        float currentTime = 0;
        float normalizedValue = 0;

        while (currentTime <= _time)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / _time;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(current, target, normalizedValue));
            yield return null;
        }

        coroutineRotate = StartCoroutine(Rotate(_time, -_rot));
    }

    private IEnumerator Scale()
    {
        yield return null;
    }
}
