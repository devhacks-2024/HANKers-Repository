using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DamageOnContact))]
public class Projectile : MonoBehaviour
{
   [SerializeField] private float speed = 100;

   public void Fire(Vector2 direction)
   {
      GetComponent<Rigidbody2D>().velocity = direction * speed;
   }
}
