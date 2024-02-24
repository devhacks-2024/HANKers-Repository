using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
   public static class Extensions
   {

      public static Vector2 ToVector2 (this Vector3 v)
      {
         return v;
      }


      public static T RandomElement<T> (this List<T> list)
      {
         return list[Random.Range(0, list.Count)];
      }
   }
}
