using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
   public class PlayerHandUI : MonoBehaviour
   {
      [SerializeField] PlayerEnum player;
      [SerializeField] List<CardSlotUI> slots = new List<CardSlotUI>();

      private void Start ()
      {
         Init(CardManager.Instance.GetPlayerHand(player));
      }

      public void Init (PlayerHand playerHand)
      {
         playerHand.OnHandChanged += PlayerHand_OnHandChanged;
         playerHand.OnDiscardIndexChanged += PlayerHand_OnDiscardIndexChanged;

         PlayerHand_OnDiscardIndexChanged(playerHand);
         PlayerHand_OnHandChanged(playerHand);
      }

      private void PlayerHand_OnDiscardIndexChanged (PlayerHand obj)
      {
         for (int i = 0; i < slots.Count; i++)
         {
            slots[i].SetIndicator(i == obj.DiscardIndex);
         }
      }

      private void PlayerHand_OnHandChanged (PlayerHand obj)
      {
         for (int i = 0; i < slots.Count; i++)
         {
            slots[i].Display(obj.GetCard(i));
         }
      }
   }
}