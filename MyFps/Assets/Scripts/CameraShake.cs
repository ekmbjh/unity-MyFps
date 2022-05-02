using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Shake(0.25f, 0.3f));
        }

    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originPos = transform.localPosition;

        float countDown = 0f;
        while (countDown < duration)
        {
            float x = originPos.x + Random.Range(-1, 1) * magnitude;
            float y = originPos.y + Random.Range(-1, 1) * magnitude;
            float z = originPos.z;
            transform.localPosition = new Vector3(x, y, z);

            countDown += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originPos;
    }
}
