using UnityEngine;

namespace Assets.Scripts
{
   public abstract class AbstractStatModelViewConfig<T, S> : MonoBehaviour
      where T : StatWrapper<S>
      where S : Stat
   {
      [SerializeField] T statWrapper;
      [SerializeField] StatUI statUI;


      // Use this for initialization
      void Start ()
      {
         if (statWrapper == null)
         {
            Debug.LogWarning($"{nameof(statWrapper)} is null");
         }

         if (statUI == null)
         {
            Debug.LogWarning($"{nameof(statUI)} is null");
         }

         statUI.Init(statWrapper.Value);
      }
   }
}