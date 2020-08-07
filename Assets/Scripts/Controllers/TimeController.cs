using GTVariable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TimeController : MonoBehaviour
{
    public FloatVariable timeLeft;
    public FloatVariable maxTime;

    [Header("Events")]
    public UnityEvent timeStarted;
    public UnityEvent timeRunOut;
    public UnityEvent timeStoped;
    public bool Counting { get; private set; } = false;


    private void Start()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        timeLeft.value = maxTime.value;
    }

    public void StartTime()
    {
        Counting = true;
        timeStarted?.Invoke();
        Debug.Log("Start time");
    }

    public void StopTime()
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
