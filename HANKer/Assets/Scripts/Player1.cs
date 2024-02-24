public class Player1 : PlayerTag
{
   public static Player1 Instance { get; private set; } = null;

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
