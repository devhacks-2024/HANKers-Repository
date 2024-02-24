using System;

namespace Assets.Scripts
{
   [Serializable]
   public class Health : Stat
   {
      public event Action<int> OnTakeDamage;
      public event Action<int> OnHeal;

      public void TakeDamage(int damage)
      {
         var actualDamage = Subtract(damage);
         if (actualDamage > 0)
         {
            OnTakeDamage?.Invoke(actualDamage);
         }
      }

      public void Heal(int heal)
      {
         var actualHeal = Add(heal);
         if (actualHeal > 0)
         {
            OnHeal?.Invoke(actualHeal);
         }
      }
   }
}
