using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FocusableTarget : MonoBehaviour
{
    public float duration;
    public CameraFocusManager manager;
    public UnityEvent onFocus;
    

    public void StartFocus()
    {
        StopAllCoroutines();
        StartCoroutine(LeaveFocus());
        onFocus?.Invoke();
    }

    private IEnumerator LeaveFocus()
    {
        yield return new WaitForSeconds(duration);
        manager.LoseFocus();
    }
}
