using UnityEngine;
using UnityEngine.Events;

public class Lockable : MonoBehaviour
{
    public bool interactionEnabled = true;
    public bool IsLock { get; private set; }
    public UnityEvent onLock;
    public UnityEvent onUnlock;
    new public SpriteRenderer renderer;
    public Material normal;
    public Material locked;

    public void Lock()
    {
        if (interactionEnabled == false) return;

        IsLock = true;
        renderer.material = locked;
        onLock?.Invoke();
    }

    public void Unlock()
    {
        if (interactionEnabled == false) return;

        IsLock = false;
        renderer.material = normal;
        onUnlock?.Invoke();
    }

    public void SetInteractionEnabled(bool enabled)
    {
        interactionEnabled = enabled;
    }
}
