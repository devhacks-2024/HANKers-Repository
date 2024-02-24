using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public static int NUM_CARD_TYPES = 5;
    public static int NUM_CARD_COLORS = 4;


    public Card[][] allCards = new Card[NUM_CARD_TYPES][];
    public List<Card> deck;


    public void Remove(Card card)
    {
        deck.Remove(card);
    }

    public void Add(Card card)
    {
        deck.Add(card);
    }
    
    
    public void InitializeAllCards()
    {
        for( int i=0; i<NUM_CARD_TYPES; i++)
        {
            allCards[i] = new Card[NUM_CARD_COLORS];
        }

        for(int i=0; i<NUM_CARD_TYPES; i++)
        {
            for(int j=0; j<NUM_CARD_COLORS; j++)
            {
                allCards[i][j] = new Card
                {
                    Type = (CardType)i,
                    Color = (CardColor)j
                };
                deck.Add(allCards[i][j]);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
