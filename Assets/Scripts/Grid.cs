using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour
{
   public readonly float OffsetX = 2f;
    public readonly float PositionY = 1.5f;
    public readonly float OffsetY = 3f;
    [SerializeField] private LevelData m_LevelData = null;
   
    public int GetColumsCount()
    {
        return m_LevelData.MaxPlayCards;
    }

    public float GetPositionX()
    {
        float x = 1f;
        x -= GetColumsCount() % 2;
        x -= OffsetX *(GetColumsCount() / 2);
        return x;
    }
}
