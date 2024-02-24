using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

[RequireComponent(typeof(HealthWrapper))]
public class HealOverTime : MonoBehaviour
{
   [SerializeField] float duration = 1;
   [SerializeField] int healAmount = 1;

   Health health;

   float timer = 0f;

   // Start is called before the first frame update
   void Start ()
   {
      health = GetComponent<HealthWrapper>().Value;
   }

   // Update is called once per frame
   void Update ()
   {
      timer += Time.deltaTime;

      if (timer > duration)
      {
         health.Heal(healAmount);
         timer -= duration;
      }
   }
}
