using UnityEngine;
using UnityEngine.Events;

public class WorldTrigger2D : MonoBehaviour
{
    public string colliderTag;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTag))
        {
            onEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTag))
        {
            onExit?.Invoke();
        }
    }
}
