using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    CardDisplay cardDisplay;
    Card cardValue;

    [SerializeField] Player myself;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cardEntered = collision.gameObject.GetComponent<CardDisplay>();
        var card = collision.gameObject.GetComponent<CardDisplay>().Card;


        if (cardEntered != null)
        {
            cardDisplay = cardEntered;
            cardValue = card;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var cardExited = collision.gameObject.GetComponent<CardDisplay>();


        if (cardExited != null && cardExited == cardDisplay)
        {
            cardDisplay = null;
            cardValue = null;
        }
    }



    void Pickup()
    {
        if(cardDisplay != null)
        {
            if(myself == Player.One)
            {
                CardManager.Instance.Player1PickUp(cardValue);
            }
            else
            {
                CardManager.Instance.Player2PickUp(cardValue);
            }
        }
    }

    public enum Player
    {
        One = 1,
        Two = 2
    }
}


