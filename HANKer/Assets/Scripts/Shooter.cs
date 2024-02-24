using System;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class Shooter : MonoBehaviour
{
   [SerializeField] Projectile projectile = null;
   [SerializeField] ParticleSystem fireEffect = null;
   [SerializeField] int damage;
   [SerializeField] float cooldownTime;

   float cooldown = 0;

   Camera cam;
   Vector2 lookInput;

   private void Start ()
   {
      cam = FindObjectOfType<Camera>();
   }

   private void Update ()
   {
      if (cooldown > 0)
      {
         cooldown -= Time.deltaTime;
      }
   }

   public void Shoot(Vector2 direction)
   {
      var proj = Instantiate(projectile, transform.position, transform.rotation);
      proj.Fire(direction, damage);


      if (fireEffect)
      {
         _ = Instantiate(fireEffect, transform.position, transform.rotation);
      }
   }

   public void OnFire(InputAction.CallbackContext context)
   {

      if (context.performed)
      {
         if (cooldown <= 0)
         {
            Shoot(lookInput);
            cooldown = cooldownTime;
         }
      }

      
   }

   public void OnLook (InputAction.CallbackContext context)
   {
      if (context.performed)
      {
         var pos = context.ReadValue<Vector2>();
         var worldPos = cam.ScreenToWorldPoint(pos);

         lookInput = (worldPos - transform.position).normalized;
      }      
   }
}
