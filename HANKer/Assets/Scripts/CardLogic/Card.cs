public class Card
{
   public CardType Type { get; set; } = CardType.None;
   public CardColor Color { get; set; } = CardColor.None;
   public CardState State { get; set; } = CardState.Deck;

   public override string ToString ()
   {
      return $"Card: {{{Type}, {Color}}}";
   }
}
