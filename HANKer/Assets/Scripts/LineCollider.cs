using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class LineCollider : MonoBehaviour
{

   private void Awake ()
   {
      SetPolygonColiderPointers();
   }

   [ContextMenu("SetPolygonColliderPointers")]
   private void SetPolygonColiderPointers ()
   {
      var line = GetComponent<LineRenderer>();
      var poly = GetComponent<PolygonCollider2D>();

      var points = new Vector3[line.positionCount];
      line.GetPositions(points);

      poly.points = points.Select(x => (Vector2)x).ToArray();
   }




   // Start is called before the first frame update
   void Start ()
   {

   }

   // Update is called once per frame
   void Update ()
   {

   }
}
