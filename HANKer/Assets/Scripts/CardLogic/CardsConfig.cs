using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "CardConfig", fileName ="CardConfig")]
public class CardsConfig : ScriptableObject
{
    [SerializeField] List<CardTypeConfig> typeConfigs;
    [SerializeField] List<CardColorConfig> colorConfigs;


    public Sprite GetSpriteFromCardType(CardType type)
    {
        return typeConfigs.First(x => x.cardType == type).sprite;
    }

    public Color GetColorFromCardColor(CardColor color)
    {
        return colorConfigs.First(x => x.cardColor == color).color;
    }

    [Serializable]
    public class CardColorConfig
    {
        [SerializeField] public CardColor cardColor;
        [SerializeField] public Color color;
    }

    [Serializable]
    public class CardTypeConfig
    {
        [SerializeField] public CardType cardType;
        [SerializeField] public Sprite sprite;
    }
}


