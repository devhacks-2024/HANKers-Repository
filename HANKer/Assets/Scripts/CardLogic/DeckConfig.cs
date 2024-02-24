using System.Collections.Generic;

public static class DeckConfig
{

   public static readonly Card[,] Cards =
   {
      {
         new Card{ Color = CardColor.White, Type = CardType.Square},
         new Card{ Color = CardColor.White, Type = CardType.Diamond},
         new Card{ Color = CardColor.White, Type = CardType.Cross},
         new Card{ Color = CardColor.White, Type = CardType.Triangle},
      },
      {
         new Card{ Color = CardColor.Red, Type = CardType.Square},
         new Card{ Color = CardColor.Red, Type = CardType.Diamond},
         new Card{ Color = CardColor.Red, Type = CardType.Cross},
         new Card{ Color = CardColor.Red, Type = CardType.Triangle},
      },
      {
         new Card{ Color = CardColor.Blue, Type = CardType.Square},
         new Card{ Color = CardColor.Blue, Type = CardType.Diamond},
         new Card{ Color = CardColor.Blue, Type = CardType.Cross},
         new Card{ Color = CardColor.Blue, Type = CardType.Triangle},
      },
      {
         new Card{ Color = CardColor.Green, Type = CardType.Square},
         new Card{ Color = CardColor.Green, Type = CardType.Diamond},
         new Card{ Color = CardColor.Green, Type = CardType.Cross},
         new Card{ Color = CardColor.Green, Type = CardType.Triangle},
      }
   };

   public static List<Card> GetCards()
   {
      var cards = new List<Card>();

      for (int i = 0; i < Cards.GetLength(0); i++)
      {
         for (int j = 0; j < Cards.GetLength(1); j++)
         {
            cards.Add(Cards[i, j]);
         }
      }

      return cards;
   }
}
