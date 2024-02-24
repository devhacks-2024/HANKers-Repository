using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{

    CardType shape; // can be 0-3
    CardColor color; // can be 0-3
}

public enum CardType
{
    None,
    Square,
    Cross
}

public enum CardColor
{
    White,
    Red,
    Green,
    Blue
}
