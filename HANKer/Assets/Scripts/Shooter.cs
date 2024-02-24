using System;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class Shooter : MonoBehaviour
{
   [Header("Projectile")]
   [SerializeField] Projectile projectile = null;
   [SerializeField] int damage;
   [SerializeField] float cooldownTime;

   [Header("Effects")]
   [SerializeField] ParticleSystem fireEffect = null;
   [SerializeField] Transform aimIndicator = null;
   [SerializeField] float aimDistance = 5.0f;


   float cooldown = 0;

   Camera cam;
   Vector2 lookInput;
   Vector2 mousePosition;

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

      lookInput = (mousePosition - (Vector2)transform.position).normalized;

      if (aimIndicator)
      {
         aimIndicator.transform.position = (Vector2)transform.position + (aimDistance * lookInput);
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
         mousePosition = cam.ScreenToWorldPoint(pos);

      }      
   }
}
