using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardDisplay : MonoBehaviour
{
    [SerializeField] CardsConfig config;


    Card card;

    public void SetCard(Card card)
    {
        this.card = card;

        var sr = GetComponent<SpriteRenderer>();

        sr.sprite = config.GetSpriteFromCardType(card.GetCardType());
        sr.color = config.GetColorFromCardColor(card.GetColor());
    }


    // Start is called before the first frame update
    void Start()
    {
        SetCard(new Card());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
