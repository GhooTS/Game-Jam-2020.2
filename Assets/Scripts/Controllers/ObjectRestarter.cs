using UnityEngine;
using UnityEngine.Events;

public class ObjectRestarter : MonoBehaviour
{
    public bool resetPosition = true;
    public UnityEvent onRestard;

    private Lockable lockable;
    private Vector3 savePosition;

    private void Start()
    {
        lockable = GetComponent<Lockable>();
        savePosition = transform.position;
    }

    public void Restart()
    {
        transform.position = savePosition;
        onRestard?.Invoke();
    }
}
