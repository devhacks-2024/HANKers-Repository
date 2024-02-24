using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shooter))]
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 0;

    private const float ZERO_VELOCITY = 0.001f;
    private const float BREAKS_FACTOR = 1.1f;

   new Rigidbody2D rigidbody2D;

   Shooter shooter;

   private Vector2 moveInput;
   private Vector2 direction;

   // Use for local initialization (GetComponent)
   private void Awake ()
   {
      Debug.Log("Awake");
      rigidbody2D = GetComponent<Rigidbody2D>();
      shooter = GetComponent<Shooter>();
   }

   // Use for subscribing to events
   private void OnEnable ()
   {
      Debug.Log("OnEnable");
   }

   // Use for un-subscribing to events
   private void OnDisable ()
   {
      Debug.Log("OnDisable");
   }

   // Start is called before the first frame update
   // Use for broader initialization using properties of other objects cached in Awake()
   void Start ()
   {
      Debug.Log("Start");
   }

   // Update is called once per frame
   void Update ()
   {
      Debug.Log("Update");
   }

   private void FixedUpdate ()
   {
        if (moveInput == Vector2.zero)
            if (rigidbody2D.velocity.magnitude < ZERO_VELOCITY)
                rigidbody2D.velocity = Vector2.zero;
            else
                rigidbody2D.velocity /= BREAKS_FACTOR;

        else
            rigidbody2D.velocity += direction;
       

        Debug.Log($"MoveInput is {moveInput}");
   }

   // Used by `Invoke Unity Events`
   public void OnMove (InputAction.CallbackContext context)
   {
      moveInput = context.ReadValue<Vector2>();

      if (moveInput != Vector2.zero)
      {
         direction = moveInput;
      }
        //Debug.Log($"MoveInput is zero {moveInput == Vector2.zero}");


        Debug.Log($"OnMove (InputAction) {moveInput}");
    }

   // Used by `Invoke Unity Events`
   public void Fire (InputAction.CallbackContext context)
   {
      if (context.started == true)
      {
         shooter.Shoot(direction);
         Debug.Log("Fire");
      }      
   }
}
