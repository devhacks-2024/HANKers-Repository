using System.Collections;

using UnityEngine;

namespace Assets.Scripts
{
   public class Stockpile : Stat
   {
      void UseAmmo()
      {
         Subtract(1);
      }

      void AddAmmo(int add)
      {
         Add(add);

      }



      // Use this for initialization
      void Start ()
      {

      }

      // Update is called once per frame
      void Update ()
      {

      }
   }
}