using UnityEngine;

public class CreateOnDestroy : MonoBehaviour
{
   [SerializeField] GameObject effect = null;


   private void OnDisable ()
   {
      CreateEffect();
   }

   private void OnDestroy ()
   {
      
   }

   void CreateEffect()
   {
      if (effect != null)
      {
         var obj = Instantiate(effect);
         obj.transform.position = transform.position;
      }
   }
}
