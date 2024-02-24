using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
   public class CardSlotUI : MonoBehaviour
   {
      [SerializeField] CardsConfig config;

      [SerializeField] Image indicator;

      public void Display(Card card)
      {
         var image = GetComponent<Image>();
         image.sprite = config.GetSpriteFromCardType(card.Type);
         image.color = config.GetColorFromCardColor(card.Color);
      }



      public void SetIndicator(bool value)
      {
         indicator.enabled = value;
      }
   }
}