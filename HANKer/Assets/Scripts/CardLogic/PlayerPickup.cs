using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
   [SerializeField] PlayerEnum myself;
   [SerializeField] bool autoPickup = true;

   CardDisplay hovering;

   PlayerHand hand;

   private void Start ()
   {
      hand = CardManager.Instance.GetPlayerHand(myself);
   }

   private void OnTriggerEnter2D (Collider2D collision)
   {
      if (collision.gameObject.TryGetComponent<CardDisplay>(out var card))
      {
         hovering = card;

         if (autoPickup)
         {
            Pickup();
         }
      }
   }

   private void OnTriggerExit2D (Collider2D collision)
   {
      if (collision.gameObject.TryGetComponent<CardDisplay>(out var card))
      {
         if (hovering && hovering == card)
         {
            hovering = null;
         }
      }
   }

   // called by Unity Event in PlayerInput
   public void Pickup (InputAction.CallbackContext context)
   {
      if (context.performed)
      {
         Pickup();
      }      
   }

   private void Pickup()
   {
      if (hovering)
      {
         hand.Add(hovering.Card);

         Destroy(hovering.gameObject);

         hovering = null;
      }
   }

   public void IncrementDiscardIndex(InputAction.CallbackContext context)
   {
      if (context.performed)
      {
         hand.IncrementIndex();
      }
   }
}
