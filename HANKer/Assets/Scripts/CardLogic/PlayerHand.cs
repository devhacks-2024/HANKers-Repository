using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHand
{
    public static int HAND_LIMIT = 4;

    List<Card> cards = new List<Card>();

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
    }
}
