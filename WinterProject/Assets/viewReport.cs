using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewReport : MonoBehaviour
{
	public float shakeLevel = 3f;// 震動幅度
	public float setShakeTime = 0.5f;   // 震動時間
	public float shakeFps = 45f;    // 震動的FPS

	private bool isshakeCamera = false;// 震動標誌
	private float fps;
	private float shakeTime = 0.0f;
	private float frameTime = 0.0f;
	private float shakeDelta = 0.005f;
	private Camera selfCamera;

	void OnEnable()
	{
		isshakeCamera = true;
		selfCamera = gameObject.GetComponent<Camera>();
		shakeTime = setShakeTime;
		fps = shakeFps;
		frameTime = 0.03f;
		shakeDelta = 0.005f;
	}

	void OnDisable()
	{
		selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
		isshakeCamera = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (isshakeCamera)
		{
			if (shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0)
				{
					enabled = false;
				}
				else
				{
					frameTime += Time.deltaTime;

					if (frameTime > 1.0 / fps)
					{
						frameTime = 0;
						selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * Random.value), shakeDelta * (-1.0f + shakeLevel * Random.value), 1.0f, 1.0f);
					}
				}
			}
		}
	}
}
