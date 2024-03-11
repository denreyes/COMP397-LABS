using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
  private List<IObserver> _observes = 
    new List<IObserver>();

  public void AddObserver(IObserver observer)
  {
    _observes.Add(observer);
  }
  public void RemoveObserver(IObserver observer)
  {
    _observes.Remove(observer);
  }
  public void NotifyObservers(PlayerEnums playerEnums)
  {
    _observes.ForEach((_observer) => 
    {
      _observer.OnNotify(playerEnums);
    });
  }
}
