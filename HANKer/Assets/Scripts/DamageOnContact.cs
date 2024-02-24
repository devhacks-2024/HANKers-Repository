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

      public string IgnoreTag { get; set; } = string.Empty;

      private void OnTriggerEnter2D (Collider2D collision)
      {
         //Debug.Log($"Ignoring {IgnoreTag}");
         //Debug.Log($"Collision's Tag: {collision.tag}");


         if (collision.gameObject.TryGetComponent<HealthWrapper>(out var health))
         {
            Debug.Log("found health");

            health.Value.TakeDamage(Damage);
         }
         else
         {
            Debug.Log("no health found");
         }
      }
   }
}