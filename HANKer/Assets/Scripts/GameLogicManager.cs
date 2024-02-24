using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Unity.Burst.Intrinsics;

using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
   public class GameLogicManager : MonoBehaviour
   {
      [Header("Player 1")]
      [SerializeField] GameObject player1Prefab = null;
      [SerializeField] PlayerModelViewConfig p1Config = null;

      [Header("Player 2")]

      [SerializeField] GameObject player2Prefab = null;
      [SerializeField] PlayerModelViewConfig p2Config = null;

      [Header("Cards")]
      [SerializeField] CardDisplay cardDisplayPrefab = null;

      [Header("Spawn Points")]
      [SerializeField] PlayerSpawnPoints playerSpawnPoints = null;
      [SerializeField] CardSpawnPoints cardSpawnPoints = null;

      static Transform p1;
      static Transform p2;




      private void Start ()
      {
         SpawnPlayers();
         SpawnCards();
      }

      private void Update ()
      {
         var card = FindFirstObjectByType<CardDisplay>();

         if (card == null)
         {
            SpawnCards();
         }
      }


      /*********************************************
       * 
       * Initial
       * - Spawn Players
       * - StartRound
       * 
       * 
       * - Detect when cards are picked up
       * - when all cards are picked up, new round.
       * 
       * 
       * 
       *********************************************/



      void SpawnPlayers ()
      {
         var positions = playerSpawnPoints.Positions;

         p1 = Instantiate(player1Prefab).transform;
         p1.position = positions[0];

         Debug.Log($"p1 {p1}, p1config {p1Config}");

         p1Config.Connect(p1.gameObject);


         p2 = Instantiate(player2Prefab).transform;
         p2.position = positions[1];
         p2Config.Connect(p2.gameObject);
      }

      bool NotNearPlayers(Vector2 v)
      {
         return Vector2.Distance(v, p1.position) > 2 && Vector2.Distance(v, p2.position) > 2;
      }

      void SpawnCards ()
      {
         var positions = cardSpawnPoints.Positions.Where(NotNearPlayers).ToList();

         List<List<Vector2>> lists = new List<List<Vector2>>
         {
            positions.Where(x => x.x < 0).ToList(),
            positions.Where(x => x.x > 0).ToList(),
            positions.Where(x => x.x > 0).ToList(),
            positions.Where(x => x.x > 0).ToList()
         };

         foreach(var l in lists)
         {
            var v = l.RandomElement();

            positions.Remove(v);

            SpawnCard(CardManager.Instance.Deck.GetCard(), v);
         }
      }

      void SpawnCard(Card card, Vector2 position)
      {
         var cardDisplay = Instantiate(cardDisplayPrefab);

         cardDisplay.transform.position = position;

         cardDisplay.SetCard(card);
      }
   }
}
