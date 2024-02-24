using UnityEngine;

public class CreateOnDestroy : MonoBehaviour
{
   [SerializeField] GameObject effect = null;

   private void OnDestroy ()
   {
      if (effect != null)
      {
         var obj = Instantiate(effect);
         obj.transform.position = transform.position;
      }
   }
}
