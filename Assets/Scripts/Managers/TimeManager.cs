using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Managers/ Time Manager" ,fileName = "Time Manager")]
public class TimeManager : ScriptableObject
{
    [Min(0)]
    public float defualtTime = 1;
    [Min(0)]
    public float timeMin = 0;
    [Min(0)]
    public float timeMax = 5;

    public UnityEvent timeStarted;
    public UnityEvent timeStopped;

    public void StopTime()
    {
        Time.timeScale = 0;
        timeStopped?.Invoke();
    }

    public void SetDefaultTime()
    {
        Time.timeScale = defualtTime;
        OnTimeStarted();
    }

    private void OnTimeStarted()
    {
        if (Time.timeScale != 0)
        {
            timeStarted?.Invoke();
        }
    }

    public void SetTime(float time)
    {
        Time.timeScale = Mathf.Clamp(time, timeMin, timeMax);
        OnTimeStarted();
    }
}
