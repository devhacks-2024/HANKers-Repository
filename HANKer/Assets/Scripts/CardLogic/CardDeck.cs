using System.Collections.Generic;
using System.Linq;

using Assets.Scripts;

public class CardDeck
{
   public List<Card> cards;

   private CardDeck (IEnumerable<Card> cards)
   {
      this.cards = cards.ToList();
   }

   public static CardDeck CreateEmptyDeck()
   {
      return new CardDeck(new List<Card>());
   }

   public static CardDeck CreateFullDeck ()
   {
      return new CardDeck(DeckConfig.GetCards());
   }


   public Card GetCard()
   {
      var c = cards.RandomElement();
      _ = cards.Remove(c);
      return c;
   }

   public void AddCard (Card c)
   {
      cards.Add(c);
   }
}
