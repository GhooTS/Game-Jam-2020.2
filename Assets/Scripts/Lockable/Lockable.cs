using UnityEngine;
using UnityEngine.Events;

public class Lockable : MonoBehaviour
{
    public bool interactionEnabled = true;
    public bool IsLock { get; private set; }
    public UnityEvent onLock;
    public UnityEvent onUnlock;

    public void Lock()
    {
        if (interactionEnabled == false) return;

        IsLock = true;
        onLock?.Invoke();
    }

    public void Unlock()
    {
        if (interactionEnabled == false) return;

        IsLock = false;
        onUnlock?.Invoke();
    }

    public void SetInteractionEnabled(bool enabled)
    {
        interactionEnabled = enabled;
    }
}
