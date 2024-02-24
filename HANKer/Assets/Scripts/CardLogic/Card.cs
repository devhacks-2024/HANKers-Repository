using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public CardType Type { get; set; } = CardType.None;
    public CardColor Color { get; set; } = CardColor.None;

    public Card(CardType type, CardColor color)
    {
        Type = type;
        Color = color;
    }

    public Card()
    {
    }

   public override string ToString ()
   {
      return $"Card: {{{Type}, {Color}}}";
   }
}

public enum CardType
{
    None = -1,
    Square = 0,
    Circle = 1,
    Diamond = 2,
    Cross = 3,
    Triangle = 4
}

public enum CardColor
{
    None = -1,
    White = 0,
    Red = 1,
    Green = 2,
    Blue = 3
}
