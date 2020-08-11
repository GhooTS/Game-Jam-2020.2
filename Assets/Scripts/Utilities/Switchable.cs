using System.Collections;
using UnityEngine;

public abstract class Switchable : MonoBehaviour
{
    [SerializeField]
    protected bool defualtState = false;

    public abstract void Switch();

    public void SwitchWithDelay(float delay)
    {
        StopAllCoroutines();
        StartCoroutine(SwitchAfterDelay(delay));
    }

    protected virtual IEnumerator SwitchAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Switch();
    }

    public abstract void Switch(bool switchOn);

    public abstract void SetInitialState();
}
