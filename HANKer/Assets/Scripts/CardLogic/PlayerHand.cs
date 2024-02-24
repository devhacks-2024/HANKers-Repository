using System;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

public class PlayerHand
{
   public const int HAND_LIMIT = 4;


   public PlayerEnum Player;

   public List<Card> Cards { get; private set; } = new List<Card>();


   public int DiscardIndex { get; private set; } = 3;

   public event Action<PlayerHand> OnHandChanged;
   public event Action<PlayerHand> OnDiscardIndexChanged;

   public PlayerHand (PlayerEnum player)
   {
      Player = player;
   }

   public void Add (Card card)
   {
      if (Cards.Count == HAND_LIMIT)
      {
         var discard = Cards[DiscardIndex];

         Cards[DiscardIndex] = card;

         CardManager.Instance.Discard(discard);
      }
      else
      {
         Cards.Add(card);
      }

      OnHandChanged?.Invoke(this);
   }

   public void RemoveRandom()
   {
      if (Cards.Count > 0)
      {
         var discard = Cards.RemoveRandom();
         CardManager.Instance.Discard(discard);

         OnHandChanged?.Invoke(this);
      }
   }

   public Card GetCard(int index)
   {
      return index < 0 || index >= Cards.Count
         ? new Card()
         : Cards[index];
   }

   public void IncrementIndex()
   {
      DiscardIndex = (DiscardIndex + 1) % HAND_LIMIT;
      OnDiscardIndexChanged?.Invoke(this);
   }
}
