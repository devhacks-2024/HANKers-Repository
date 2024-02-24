using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shooter))]
public class PlayerMovement : MonoBehaviour
{
    PhotonView view;
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
      rigidbody2D = GetComponent<Rigidbody2D>();
      shooter = GetComponent<Shooter>();
   }

   // Use for subscribing to events
   private void OnEnable ()
   {
   }

   // Use for un-subscribing to events
   private void OnDisable ()
   {
   }

   // Start is called before the first frame update
   // Use for broader initialization using properties of other objects cached in Awake()
   void Start ()
   {
        view = GetComponent<PhotonView>();
   }

   // Update is called once per frame
   void Update ()
   {
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
    public void OnMove(InputAction.CallbackContext context)
    {
        if (view.IsMine) {

            moveInput = context.ReadValue<Vector2>();

            if (moveInput != Vector2.zero)
            {
                direction = moveInput;
            }
            //Debug.Log($"MoveInput is zero {moveInput == Vector2.zero}");


            Debug.Log($"OnMove (InputAction) {moveInput}");
        }
    }

   // Used by `Invoke Unity Events`
   public void Fire (InputAction.CallbackContext context)
   {
      if (view.IsMine && context.started == true)
      {
         shooter.Shoot(direction);
      }      
   }
}
