using System;

using UnityEngine;

namespace Assets.Scripts
{
   [Serializable]
   public class Stat
   {
      [SerializeField] private int max = 100;
      [SerializeField] private int start = 100;
      [SerializeField] private int min = 0;

      int curr;

      public event Action<Stat> OnValueChanged;

      public int Max => max;
      public int Min => min;

      public int Current {
         get => curr;
         set => curr = value;
      }

      public void Init()
      {
         curr = start;
      }

      protected void Modify(int amount)
      {
         if (amount == 0)
            return;

         Current = Math.Clamp(Min, Current + amount, Max);
         OnValueChanged?.Invoke(this);
      }

      protected int Add(int value)
      {
         var add = Math.Min(value, Max - Current);
         if (add > 0)
         {
            Current+= add;
            OnValueChanged?.Invoke(this);
         }

         return add;
      }

      protected int Subtract(int value)
      {
         var subtract = Math.Min(value, Current - Min);
         if (subtract > 0)
         {
            Current-= subtract;
            OnValueChanged?.Invoke(this);
         }

         return subtract;
      }

      protected void Set(int value)
      {
         if (curr == value)
            return;

         Current = value;
         OnValueChanged?.Invoke(this);
      }
   }
}
