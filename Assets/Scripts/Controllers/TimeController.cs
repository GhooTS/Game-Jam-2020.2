using GTVariable;
using UnityEngine;
using UnityEngine.Events;

public class TimeController : MonoBehaviour
{
    public FloatVariable timeLeft;
    public FloatVariable maxTime;

    [Header("Events")]
    public UnityEvent timeStarted;
    public UnityEvent timeRunOut;
    public UnityEvent timeStoped;
    public bool Counting { get; private set; } = false;


    private void OnEnable()
    {
        RestartTimer();
    }

    public void RestartTimer()
    {
        timeLeft.value = maxTime.value;
    }

    public void StartTime()
    {
        Counting = true;
        timeStarted?.Invoke();
    }

    public void StopCountDown()
    {
        Counting = false;
        timeStoped?.Invoke();
    }

    private void Update()
    {
        if (Counting == false) return;

        if (timeLeft.value > 0f)
        {
            timeLeft.value -= Time.deltaTime;
        }
        else
        {
            Counting = false;
            timeRunOut?.Invoke();
        }
    }
}
