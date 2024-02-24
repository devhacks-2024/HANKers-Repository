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
      [Header("Prefabs")]
      [SerializeField] GameObject player1Prefab = null;
      [SerializeField] GameObject player2Prefab = null;
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

         p2 = Instantiate(player2Prefab).transform;
         p2.position = positions[1];

      }

      bool NotNearPlayers(Vector2 v)
      {
         return Vector2.Distance(v, p1.position) > 2 && Vector2.Distance(v, p2.position) > 2;
      }

      void SpawnCards ()
      {

         Debug.Log("Card Positions");
         var positions = cardSpawnPoints.Positions;

         positions = positions.Where(NotNearPlayers).ToList();



         var cards = new List<Card>
         {
            new Card(CardType.Square, CardColor.White),
            new Card(CardType.Square, CardColor.Green),
            new Card(CardType.Square, CardColor.Blue),
            new Card(CardType.Square, CardColor.Red),

            new Card(CardType.Diamond, CardColor.White),
            new Card(CardType.Diamond, CardColor.Green),
            new Card(CardType.Diamond, CardColor.Blue),
            new Card(CardType.Diamond, CardColor.Red),

            new Card(CardType.Circle, CardColor.White),
            new Card(CardType.Circle, CardColor.Green),
            new Card(CardType.Circle, CardColor.Blue),
            new Card(CardType.Circle, CardColor.Red)
         };

         List<List<Vector2>> lists = new List<List<Vector2>>
         {
            positions.Where(x => x.x < 0).ToList(),
            positions.Where(x => x.x > 0).ToList(),
            positions.Where(x => x.x > 0).ToList(),
            positions.Where(x => x.x > 0).ToList()
         };

         //var leftPositions    = positions.Where(x => x.x < 0).ToList();
         //var rightPositions   = positions.Where(x => x.x > 0).ToList();
         //var topPositions     = positions.Where(x => x.x > 0).ToList();
         //var bottomPositions  = positions.Where(x => x.x > 0).ToList();

         //var v = GetRandom(leftPositions);

         foreach(var l in lists)
         {
            var v = l.RandomElement();

            positions.Remove(v);

            SpawnCard(cards.RandomElement(), v);
         }



         //for (int i = 0; i < 2; i++)
         //{
         //   int index = 0;

         //   while (index == 0)
         //   {
         //      index = UnityEngine.Random.Range(0, positions.Count);

         //      if (positions[index].x >= 0)
         //      {
         //         index = 0;
         //      }
         //   }


         //   SpawnCard(card, positions[index]);
         //   positions.RemoveAt(index);
         //}
      }


      void SpawnCard(Card card, Vector2 position)
      {
         var cardDisplay = Instantiate(cardDisplayPrefab);

         cardDisplay.transform.position = position;

         cardDisplay.SetCard(card);

      }


      Vector2 GetRandom(List<Vector2> list)
      {
         return list[UnityEngine.Random.Range(0, list.Count)];
      }


   }
}
