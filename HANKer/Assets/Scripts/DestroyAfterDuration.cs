using UnityEngine;

namespace Assets.Scripts
{
   public class DestroyAfterDuration : MonoBehaviour
   {
      [SerializeField] float duration = 1f;
      // Use this for initialization
      void Start ()
      {
         Destroy(gameObject, duration);
      }
   }
}