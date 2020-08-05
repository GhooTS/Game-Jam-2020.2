using GTVariable;
using UnityEngine;

public class TimeEventTrigger : MonoBehaviour
{
    public FloatVariable timeLeft;
    public FloatVariable maxTime;
    public TimeEvent[] timeEvents;

    private void OnEnable()
    {
        ResetEvents();
    }

    private void Update()
    {
        InvokeEvents();
    }

    public void InvokeEvents()
    {
        for (int i = 0; i < timeEvents.Length; i++)
        {
            timeEvents[i].Invoke(maxTime.value - timeLeft.value);
        }
    }

    public void ResetEvents()
    {
        for (int i = 0; i < timeEvents.Length; i++)
        {
            timeEvents[i].Reset();
        }
    }
}
