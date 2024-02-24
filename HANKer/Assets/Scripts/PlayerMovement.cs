using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shooter))]
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 10;

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
   }

   // Update is called once per frame
   void Update ()
   {
   }

   private void FixedUpdate ()
   {
      rigidbody2D.velocity = moveSpeed * moveInput;
   }

   // Used by `Invoke Unity Events`
   public void OnMove (InputAction.CallbackContext context)
   {
      moveInput = context.ReadValue<Vector2>();

      if (moveInput != Vector2.zero)
      {
         direction = moveInput;
      }
   }

   // Used by `Invoke Unity Events`
   public void Fire (InputAction.CallbackContext context)
   {
      if (context.started == true)
      {
         shooter.Shoot(direction);
      }      
   }
}
