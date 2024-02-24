using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
   [SerializeField] List<Transform> spawnPoints = new List<Transform>();

   public List<Vector2> Positions => spawnPoints.Select(x => (Vector2)x.position).ToList();
}


