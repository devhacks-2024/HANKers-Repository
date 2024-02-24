using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StockpileWrapper : MonoBehaviour
{
   [SerializeField] int maxAmmo = 10;
   [SerializeField] int startingAmmo = 5;

   int currAmmo;

   // Start is called before the first frame update
   void Start ()
   {
      currAmmo = startingAmmo;
   }
}


