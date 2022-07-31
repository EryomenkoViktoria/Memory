using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresedCards : MonoBehaviour
{
      
    private Sprite m_BackSprite = null;
    private List<Sprite> m_AllSprites = null;
    [SerializeField]
    private LevelData m_LevelData= null;
    private readonly ResorcesLoader resorcesLoader = new ResorcesLoader();
    [SerializeField]
    private UnityEvent m_OnLoaded = new UnityEvent();

    public void GetSprites()
    {
        Theme theme = resorcesLoader.GetTheme(m_LevelData.ThemeName);
        m_BackSprite = theme.BackSprite;
        m_AllSprites = theme.AllSprites;
        m_OnLoaded.Invoke();
    }

    public Sprite GetBackSprite()
    {
        return m_BackSprite;
    }

    public List <Sprite> GetPlayCardsSprites()
    {
        List<Sprite> sprites = new List<Sprite>(m_AllSprites);
        while (m_LevelData.MaxPlayCards< sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));
        }
        return sprites;
    }

    public int[] GetCardIndex()
    {
        int[] cardIndex = new int[m_LevelData.MaxPlayCards*2];
        for (int i=0; i< cardIndex.Length; i++)
        {
            cardIndex[i] = i / 2;
        }
        for(int i=0; i< cardIndex.Length; i++)
        {
            int temp = cardIndex[i];
            int rnd = Random.Range(0,cardIndex.Length);
            cardIndex[i] = cardIndex[rnd];
            cardIndex[rnd] = temp;
        }
        return cardIndex;
    }
}
