using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
   public class CardSlotUI : MonoBehaviour
   {
      [SerializeField] CardsConfig config;

      public void Display(Card card)
      {
         var image = GetComponent<Image>();
         image.sprite = config.GetSpriteFromCardType(card.Type);
         image.color = config.GetColorFromCardColor(card.Color);
      }
   }
}