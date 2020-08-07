using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ResetableManager : MonoBehaviour
{
    public List<Resetable> resetables;

    private void Start()
    {
        resetables = FindObjectsOfType<Resetable>().ToList();
    }

    public void Add(Resetable resetable)
    {
        if(resetables.Contains(resetable) == false)
        {
            resetables.Add(resetable);
        }
    }

    public void Remove(Resetable resetable)
    {
        resetables.Remove(resetable);
    }

    public void ResetAll()
    {
        foreach (var resetable in resetables)
        {
            resetable.ResetState();
        }
    }
}
