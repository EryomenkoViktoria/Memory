using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{ 
    private float m_TargetSizeX = 1280.0f;
    private float m_TargetSizeY = 720.0f;
    private const float HalfSize = 200.0f;

    private void Awake()
    {
        CameraResize();
    }

    private void CameraResize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = m_TargetSizeX / m_TargetSizeY;
        if(screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float differetSize = targetRatio / screenRatio;
            Resize(differetSize);
        }
    }

    private void Resize(float diferentSize =1.0f)
    {
        Camera.main.orthographicSize = m_TargetSizeX / HalfSize * diferentSize;
    }
}
