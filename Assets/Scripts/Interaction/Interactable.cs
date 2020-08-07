using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour,IInteractable
{
    public UnityEvent onInteraction;
    [SerializeField]
    private bool canInteract = true;

    public void Interact()
    {
        if (canInteract == false) return;
        onInteraction?.Invoke();    
    }

    public void SetEnabledInteraction(bool enabled)
    {
        canInteract = enabled;
    }
}
