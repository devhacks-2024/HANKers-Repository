using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
   public class PlayerHandUI : MonoBehaviour
   {
      [SerializeField] PlayerEnum player;
      [SerializeField] List<CardSlotUI> slots = new List<CardSlotUI>();


      private void Awake ()
      {
         Debug.Log("Hello World");
      }

      private void Start ()
      {
         Debug.Log("PlayerHandUI");
         Init(CardManager.Instance.GetPlayerHand(player));
      }

      public void Init (PlayerHand playerHand)
      {
         Debug.Log("Init");
         playerHand.OnHandChanged += PlayerHand_OnHandChanged;

         PlayerHand_OnHandChanged(playerHand);
      }

      private void PlayerHand_OnHandChanged (PlayerHand obj)
      {
         Debug.Log("PlayerHand_OnHandChanged");


         for (int i = 0; i < slots.Count; i++)
         {
            slots[i].Display(obj.GetCard(i));
         }
      }
   }
}