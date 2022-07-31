using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardsSpawner : MonoBehaviour
{
    [SerializeField]
    private Grid m_Grid=null;
    [SerializeField] 
    private PresedCards m_PresetCards = null;
    [SerializeField]
    private Card m_CardPrefab = null;
    [SerializeField]
    private UnityEvent m_StartCollect = new UnityEvent();

    public void Spawn()
    {
        Transform localTransform = GetComponent<Transform>();
        Card card;
        Sprite backSprite = m_PresetCards.GetBackSprite();
        List <Sprite> playCardsSprites = m_PresetCards.GetPlayCardsSprites();

        
            int[] playCardsIndex = m_PresetCards.GetCardIndex();
            float positionX = m_Grid.GetPositionX();
            float positionY = m_Grid.PositionY;
            int count = m_Grid.GetColumsCount();
            
            for(int j =0; j< playCardsIndex.Length; j++)
            {
                card= Instantiate(m_CardPrefab) as Card;
                card.transform.position = new Vector3(positionX, positionY+ localTransform.position.y);
                card.transform.parent = localTransform;
                card.CardsSetting(backSprite, playCardsSprites[playCardsIndex[j]], playCardsIndex[j]);
                positionX += m_Grid.OffsetX;
                count--;
                if(count < 1)
                {
                    count=m_Grid.GetColumsCount();
                    positionY-=m_Grid.OffsetY;
                    positionX =m_Grid.GetPositionX();
                }
            }
            
        

        m_StartCollect.Invoke();  
    }
}
