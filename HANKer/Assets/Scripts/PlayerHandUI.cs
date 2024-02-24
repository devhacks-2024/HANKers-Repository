using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
   public class PlayerHandUI : MonoBehaviour
   {
      [SerializeField] List<CardSlotUI> slots = new List<CardSlotUI>();
      

      
   }


   public class CardSlotUI : MonoBehaviour
   {
      [SerializeField] Image image;
      [SerializeField] CardsConfig config;



      void Set(Card card)
      {
         image.sprite = config.GetSpriteFromCardType(card.Type);
         image.color = config.GetColorFromCardColor(card.Color);
      }
   }
}