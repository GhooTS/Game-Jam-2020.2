using UnityEngine.Events;

[System.Serializable]
public class TimeEvent
{
    public float timeToPass;
    public UnityEvent onTimePass;
    public bool wasInvoke = false;

    public void Invoke()
    {
        if (wasInvoke == false)
        {
            onTimePass?.Invoke();
            wasInvoke = true;
        }
    }

    public void Reset()
    {
        wasInvoke = false;
    }
}
