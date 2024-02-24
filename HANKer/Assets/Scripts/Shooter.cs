using Assets.Scripts;

using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Shooter : MonoBehaviour
{
   [SerializeField] Projectile projectile = null;
   [SerializeField] int damage;

   public void Shoot(Vector2 direction)
   {
      var proj = Instantiate(projectile);

      proj.transform.position = transform.position;

      var damageOnContact = proj.GetComponent<DamageOnContact>();

      Debug.Log($"Shooter.Shoot {tag}");


      damageOnContact.Damage = damage;
      damageOnContact.IgnoreTag = tag;

      proj.Fire(direction);
   }
}
