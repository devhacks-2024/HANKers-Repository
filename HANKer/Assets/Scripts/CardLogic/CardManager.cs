using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public CardDeck gameDeck = new CardDeck();

    public PlayerHand hand1 = new PlayerHand();
    public PlayerHand hand2 = new PlayerHand();
    public PlayerHand playingField = new PlayerHand();

    //all cards start in the game deck, then some go to playing field, cards can go:
    //  -from deck to field (placed)
    //  -from field to a hand (picked up)
    //  -from hands to field (dropped)
    //  -from hands to deck  (destroyed)

    public void Place(Card card)
    {
        gameDeck.Remove(card);
        playingField.Add(card);
    }

    public void Player1PickUp(Card card)
    {
        playingField.Remove(card);
        hand1.Add(card);
    }

    public void Player2PickUp(Card card)
    {
        playingField.Remove(card);
        hand2.Add(card);
    }

    public void Player1Drop(Card card)
    {
        hand1.Remove(card);
        playingField.Add(card);
    }

    public void Player2Drop(Card card)
    {
        hand2.Remove(card);
        playingField.Add(card);
    }

    public void Player1DestroyCard(Card card)
    {
        hand1.Remove(card);
        gameDeck.Add(card);
    }

    public void Player2DestroyCard(Card card)
    {
        hand2.Remove(card);
        gameDeck.Add(card);
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
