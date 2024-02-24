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

      public static T RemoveRandom<T> (this List<T> list)
      {
         var x = list[Random.Range(0, list.Count)];

         list.Remove(x);

         return x;
      }
   }
}
