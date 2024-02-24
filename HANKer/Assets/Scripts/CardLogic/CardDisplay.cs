using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class CardDisplay : MonoBehaviour
{
   [SerializeField] CardsConfig config;

   public Card Card { get; set; }

   public void SetCard (Card card)
   {
      Card = card;

      card.State = CardState.World;

      var sr = GetComponent<SpriteRenderer>();

      sr.sprite = config.GetSpriteFromCardType(card.Type);
      sr.color = config.GetColorFromCardColor(card.Color);
   }
}
