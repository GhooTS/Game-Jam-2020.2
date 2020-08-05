using UnityEngine;
using UnityEngine.Events;

public class Lockable : MonoBehaviour
{
    public bool IsLock { get; private set; }
    public UnityEvent onLock;
    public UnityEvent onUnlock;

    public void Lock()
    {
        IsLock = true;
        onLock?.Invoke();
    }

    public void Unlock()
    {
        IsLock = false;
        onUnlock?.Invoke();
    }
}
