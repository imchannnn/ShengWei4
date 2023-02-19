using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeStrength = 10f;    // 晃動的強度
    public float shakeFrequency = 10.0f;   // 晃動的頻率
    public float shakeDuration = 10.0f;    // 晃動的持續時間

    private Vector3 originalPos;          // 原始的位置
    private float timeElapsed = 0.0f;     // 已經過的時間

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    private void Update()
    {
        if (timeElapsed < shakeDuration)
        {
            // 使用Perlin Noise計算偏移量
            float xOffset = Mathf.PerlinNoise(Time.time * shakeFrequency, 0.0f) * shakeStrength;
            float yOffset = Mathf.PerlinNoise(0.0f, Time.time * shakeFrequency) * shakeStrength;

            // 設置新的位置
            transform.localPosition = originalPos + new Vector3(xOffset, yOffset, 0.0f);

            // 更新已經過的時間
            timeElapsed += Time.deltaTime;
        }
        else
        {
            // 還原位置
            transform.localPosition = originalPos;
        }
    }
}
