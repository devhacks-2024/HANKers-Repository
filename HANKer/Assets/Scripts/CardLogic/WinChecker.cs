using TMPro;

using UnityEngine;

public class WinChecker : MonoBehaviour
{
   [SerializeField] GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
      CardManager.Instance.GetPlayerHand(PlayerEnum.P1).OnHandChanged += WinChecker_OnHandChanged;
      CardManager.Instance.GetPlayerHand(PlayerEnum.P2).OnHandChanged += WinChecker_OnHandChanged;
    }

   private void WinChecker_OnHandChanged (PlayerHand obj)
   {
      var c0 = obj.GetCard(0);
      var c = c0.Color;
      var t = c0.Type;

      Debug.Log("Comparing to " + c0);

      bool win = true;
      for (int i = 0; i < PlayerHand.HAND_LIMIT; i++)
      {
         var card = obj.GetCard (i);


         if (card.Color != c)
         {
            win = false;
         }

         Debug.Log($"Comparing {card}, win={win}");
      }

      if (!win)
      {
         win = true;

         for (int i = 0; i < PlayerHand.HAND_LIMIT; i++)
         {
            var card = obj.GetCard (i);


            if (card.Type != t)
            {
               win = false;
            }

            Debug.Log($"Comparing {card}, win={win}");
         }
      }

      if (win)
      {
         var x = Instantiate(canvas);

         var text = x.GetComponentInChildren<TextMeshProUGUI>();
         text.text = $"Player {(obj.Player == PlayerEnum.P1 ? "1" : "2")} Wins";
      }
   }
}
