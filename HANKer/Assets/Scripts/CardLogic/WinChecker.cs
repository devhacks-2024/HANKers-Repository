using UnityEngine;
using UnityEngine.WSA;

public class WinChecker : MonoBehaviour
{
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

      bool win = true;
      for (int i = 0; i < PlayerHand.HAND_LIMIT; i++)
      {
         var card = obj.GetCard (i);

         if (card.Color != c || card.Type != t)
         {
            win = false;
         }
      }

      if (win)
      {

      }
   }
}