using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeStrength = 10f;    // �̰ʪ��j��
    public float shakeFrequency = 10.0f;   // �̰ʪ��W�v
    public float shakeDuration = 10.0f;    // �̰ʪ�����ɶ�

    private Vector3 originalPos;          // ��l����m
    private float timeElapsed = 0.0f;     // �w�g�L���ɶ�

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    private void Update()
    {
        if (timeElapsed < shakeDuration)
        {
            // �ϥ�Perlin Noise�p�ⰾ���q
            float xOffset = Mathf.PerlinNoise(Time.time * shakeFrequency, 0.0f) * shakeStrength;
            float yOffset = Mathf.PerlinNoise(0.0f, Time.time * shakeFrequency) * shakeStrength;

            // �]�m�s����m
            transform.localPosition = originalPos + new Vector3(xOffset, yOffset, 0.0f);

            // ��s�w�g�L���ɶ�
            timeElapsed += Time.deltaTime;
        }
        else
        {
            // �٭��m
            transform.localPosition = originalPos;
        }
    }
}
