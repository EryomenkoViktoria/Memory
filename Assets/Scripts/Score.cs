using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const int Add = 60;
    private const int Remove = -20;
    private int m_Value;
    [SerializeField] private IntEvent m_OnUpdated = new IntEvent();
    public void ResetScore()
    {
        m_Value = 0;
        m_OnUpdated.Invoke(m_Value);
    }

    public void AddRemove(bool addRemove)
    {
        m_Value += addRemove == true ? Add : Remove;

        if (m_Value< 0)
        {
            m_Value = 0;
        }
        m_OnUpdated.Invoke(m_Value);
    }
}

[System.Serializable]
public class IntEvent : UnityEvent<int> { }
