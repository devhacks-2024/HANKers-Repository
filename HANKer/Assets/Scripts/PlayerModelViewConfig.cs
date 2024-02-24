using System;

using UnityEngine;

namespace Assets.Scripts
{
   [Serializable]
   public class PlayerModelViewConfig
   {
      [SerializeField] StatUI healthUI = null;


      public void Connect(GameObject player)
      {
         healthUI.Init(player.GetComponent<HealthWrapper>().Value);
      }
   }
}