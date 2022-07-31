using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour,IPointerClickHandler
{
    private SpriteRenderer m_SpriteRenderer;
    private Sprite m_BackSprite;
    private Sprite m_FrontSprite;
    private Animation m_Animation;
    private bool m_IsBackSide = true;
    private BoxCollider2D m_BoxCollider2D;
    public CardCollector m_CardCollector;
    public int Index {get;set;}
    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Animation=GetComponent<Animation>();
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_CardCollector.TwoCardsClosed())
        {
            m_BoxCollider2D.enabled = false;
            CardAnimation();
            m_CardCollector.OpenCard(this);
        }

    }


    private void EnsledColider()
    {
        m_BoxCollider2D.enabled = true;
    }

    private void ChangeScripteCard()
    {
        m_SpriteRenderer.sprite=m_IsBackSide == true ? m_BackSprite : m_FrontSprite;
    }

    public void CardAnimation()
    {
        m_IsBackSide =! m_IsBackSide;
        m_Animation.Play(m_IsBackSide == true ? "ToBack" : "ToFront") ;

        //if (m_IsBackSide)
        //{
        //    m_Animation.Play("ToBack");

        //}
        //else
        //{
        //    m_Animation.Play("ToFront");
        //}
    }

   public void CardsSetting(Sprite back, Sprite front, int index)
    {
        m_SpriteRenderer.sprite = m_BackSprite = back;
        m_FrontSprite = front;
        Index = index;
    }

    public void SetCardCollector(CardCollector cardCollector)
    {
        m_CardCollector = cardCollector;
    }

    
}
