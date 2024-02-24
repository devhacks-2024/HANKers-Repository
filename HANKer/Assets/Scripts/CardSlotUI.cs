using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
   public class CardSlotUI : MonoBehaviour
   {
      [SerializeField] Image image;
      [SerializeField] CardsConfig config;

      public void Set(Card card)
      {
         image.sprite = config.GetSpriteFromCardType(card.Type);
         image.color = config.GetColorFromCardColor(card.Color);
      }
   }
}