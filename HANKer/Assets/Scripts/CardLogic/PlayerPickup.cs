using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
   [SerializeField] PlayerEnum myself;




   CardDisplay hovering;


   private void OnTriggerEnter2D (Collider2D collision)
   {
      //var cardEntered = collision.gameObject.GetComponent<CardDisplay>();
      var card = collision.gameObject.GetComponent<CardDisplay>();

      if (card != null)
      {
         hovering = card;
      }
   }

   private void OnTriggerExit2D (Collider2D collision)
   {
      var card = collision.gameObject.GetComponent<CardDisplay>();

      //var cardExited = collision.gameObject.GetComponent<CardDisplay>();

      if (card != null && hovering == card)
      {
         hovering = null;
      }
   }


   // called by Unity Event in PlayerInput
   public void Pickup (InputAction.CallbackContext context)
   {
      if (context.performed)
      {
         if (hovering != null)
         {
            CardManager.Instance.GetPlayerHand(myself).Add(hovering.Card);
            Destroy(hovering.gameObject);
         }
      }      
   }
}


