using System;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

public class PlayerHand
{
   public const int HAND_LIMIT = 4;

   List<Card> cards = new List<Card>();


   int nextToDelete = 3;

   public event Action<PlayerHand> OnHandChanged;


   public void Add (Card card)
   {
      if (cards.Count == HAND_LIMIT)
      {
         var discard = cards[nextToDelete];


         cards[nextToDelete] = card;

         CardManager.Instance.Discard(discard);
      }
      else
      {
         cards.Add(card);
      }

      OnHandChanged?.Invoke(this);
   }

   public void RemoveRandom()
   {
      if (cards.Count > 0)
      {
         var discard = cards.RemoveRandom();
         CardManager.Instance.Discard(discard);

         OnHandChanged?.Invoke(this);
      }
   }
}
