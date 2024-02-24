using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class StatUI : MonoBehaviour
{
   private Slider slider;

   private void Awake ()
   {
      slider = GetComponent<Slider>();
   }

   public void Init(Stat health)
   {
      health.OnValueChanged += Health_OnHealthChanged;

      slider.minValue = 0;
      slider.maxValue = health.Max;
      slider.value = health.Current;
   }

   private void Health_OnHealthChanged (Stat health)
   {
      Debug.Log($"Health_OnHealthChanged: {health.Current}");
      
      slider.value = health.Current;
   }
}
