using Assets.Scripts;

public abstract class StatWrapper<T> : BaseWrapper<T> where T:Stat
{
   private void Awake ()
   {
      obj.Init();
   }
}
