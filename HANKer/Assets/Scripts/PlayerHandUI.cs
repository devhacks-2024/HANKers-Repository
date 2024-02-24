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
      }

      private void PlayerHand_OnHandChanged (PlayerHand obj)
      {
         for (int i = 0; i < slots.Count; i++)
         {
            slots[i].Set(obj.Cards[i] ?? new Card());
         }
      }
   }
}