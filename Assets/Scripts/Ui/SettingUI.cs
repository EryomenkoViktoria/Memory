using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private LevelData m_LevelData = null;
    [SerializeField] private Button m_EasyButton = null;
    [SerializeField] private Button m_ThemeButton = null;

    public void SetDifficult(int value)
    {
        m_LevelData.MaxPlayCards = value;
    }

    public void  SetTheme(string name)
    {
        m_LevelData.ThemeName = name;
    }

    private void OnEnable()
    {
        m_EasyButton.onClick.Invoke();
        m_ThemeButton.onClick.Invoke();
    }
}

