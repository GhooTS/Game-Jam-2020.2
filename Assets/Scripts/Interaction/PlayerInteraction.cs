using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public string interactionObjectName;
    public LayerMask interactionMask;
    [Min(0.1f)]
    public float interactionRadius;
    public IInteractable interactable;
    [Header("Events")]
    public UnityEvent onInteracted;
    public UnityEvent onInteractionChanged;
    public UnityEvent onInteractionLost;

    public PlayerInteraction(float interactionRadius)
    {
        this.interactionRadius = interactionRadius;
    }

    private void FixedUpdate()
    {
        var result = Physics2D.CircleCastAll(transform.position, interactionRadius,Vector2.zero,Mathf.Infinity,interactionMask);

        if (result.Length == 0)
        {
            if(interactable != null)
            {
                interactable = null;
                interactionObjectName = "";
                onInteractionLost?.Invoke();
            }
            return;
        }

        var oldInteractable = interactable;
        var closes = Mathf.Infinity;
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i].collider.TryGetComponent(out IInteractable interactable))
            {
                var distance = Vector2.Distance(result[i].point, result[i].transform.position);
                if(closes > distance)
                {
                    this.interactable = interactable;
                    closes = distance;
                    interactionObjectName = result[i].transform.name;
                }
            }
        }

        if(oldInteractable != interactable)
        {
            onInteractionChanged?.Invoke();
        }
    }

    public void Interact()
    {
        if(interactable != null)
        {
            interactable.Interact();
            onInteracted?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
