public class Player2 : PlayerTag
{
   public static Player2 Instance { get; private set; } = null;

   private void Awake ()
   {
      if (Instance != null)
      {
         DestroyImmediate(gameObject);
         return;
      }

      Instance = this;
   }

   private void OnDestroy ()
   {
      Instance = null;
   }
}
