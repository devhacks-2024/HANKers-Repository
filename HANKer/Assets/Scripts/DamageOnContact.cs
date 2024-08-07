using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
   public class DamageOnContact : MonoBehaviour
   {
      [SerializeField] private int damage = 50;

      public int Damage {
         get => damage;
         set => damage = value;
      }

      private void OnTriggerEnter2D (Collider2D collision)
      {
         if (collision.gameObject.TryGetComponent<HealthWrapper>(out var health))
         {
            health.Value.TakeDamage(Damage);
         }
      }
   }
}