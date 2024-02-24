using Assets.Scripts;

using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Shooter : MonoBehaviour
{
   [SerializeField] Projectile projectile = null;
   [SerializeField] ParticleSystem fireEffect = null;
   [SerializeField] int damage;

   public void Shoot(Vector2 direction)
   {
      var proj = Instantiate(projectile, transform.position, transform.rotation);
      proj.Fire(direction, damage);

      Instantiate(fireEffect, transform.position, transform.rotation);
   }
}
