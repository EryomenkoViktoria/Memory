using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardCollector : MonoBehaviour
{
    private Card m_FirstCard;
    private Card m_SecondCard;
    private int m_CountCards;
    [SerializeField] private BoolEvent m_ScoreAdd = new BoolEvent();
    [SerializeField] private UnityEvent m_OnGameEnded = new UnityEvent();


    public void FindCards()
    {
        Card[] cards = FindObjectsOfType<Card>();
        m_CountCards = cards.Length;

        for (int i=0; i< cards.Length; i++)
        {
            cards[i].SetCardCollector(this);
        }

        //cards[0].CardsSetting(Back, Front1, 0);
        //cards[1].CardsSetting(Back, Front2, 1);
        //cards[2].CardsSetting(Back, Front1, 0);
        //cards[3].CardsSetting(Back, Front1, 1);
    }
    public void OpenCard(Card card)
    {
        if (m_FirstCard== null)
        {
            m_FirstCard = card;
        }

        else
        {
            m_SecondCard = card;
           Invoke(nameof(CompareCards), 0.7f);
        }
    }

    private void CompareCards()
    {
        if (m_FirstCard.Index == m_SecondCard.Index)
        {
            Destroy(m_FirstCard.gameObject);
            Destroy(m_SecondCard.gameObject);
            m_CountCards -= 2;
            m_ScoreAdd.Invoke(true);
            if (m_CountCards < 2)
            {
                m_OnGameEnded.Invoke();
            }
        }
        else
        {
            m_SecondCard.CardAnimation();
            m_FirstCard.CardAnimation();
            m_ScoreAdd.Invoke(false);
        }

        m_SecondCard = null;
        m_FirstCard = null;
    }

    public bool TwoCardsClosed()
    {
        return m_SecondCard == null;
    }
}
[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }