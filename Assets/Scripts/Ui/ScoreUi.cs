using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUi : MonoBehaviour
{
    private Text m_Text;
    private void Awake()
    {
        m_Text = GetComponent<Text>();
    }

    public void UpdateText(int value)
    {
        m_Text.text = value.ToString();
    }
}
