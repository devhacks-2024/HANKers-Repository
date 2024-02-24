using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class BaseWrapper<T> : MonoBehaviour
{
   [SerializeField] protected T obj;

   public T Value => obj;
}
