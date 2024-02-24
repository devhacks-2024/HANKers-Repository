using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardDisplay : MonoBehaviour
{
    [SerializeField] CardsConfig config;


    public Card Card { get; set; }

    public void SetCard(Card card)
    {
        Card = card;

        var sr = GetComponent<SpriteRenderer>();

        sr.sprite = config.GetSpriteFromCardType(card.Type);
        sr.color = config.GetColorFromCardColor(card.Color);
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
