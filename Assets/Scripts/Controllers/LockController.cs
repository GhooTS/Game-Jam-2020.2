using Boo.Lang;
using GTVariable;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class LockController : MonoBehaviour
{
    public LayerMask interactionMask;
    public float interactionRadius;
    public IntReference maxLock;
    private List<Lockable> lockables;
    public Lockable present;

    private void Start()
    {
        lockables = new List<Lockable>();   
    }

    private void FixedUpdate()
    {
        var result = Physics2D.CircleCastAll(transform.position, interactionRadius, Vector2.zero, Mathf.Infinity, interactionMask);

        if (result.Length == 0)
        {
            if (present != null)
            {
                present = null;
            }
            return;
        }

        var closes = Mathf.Infinity;
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i].collider.TryGetComponent(out Lockable lockable))
            {
                var distance = Vector2.Distance(result[i].point, result[i].transform.position);
                if (closes > distance)
                {
                    present = lockable;
                    closes = distance;
                }
            }
        }
    }


    public void SwitchLock(InputAction.CallbackContext ctx)
    {

        var button = ctx.control as ButtonControl;

        if (ctx.phase == InputActionPhase.Started && button.wasPressedThisFrame && present != null)
        {
            if (lockables.Contains(present) && present.IsLock)
            {
                lockables.Remove(present);
                present.Unlock();
            }
            else
            {
                if(lockables.Count >= maxLock)
                {
                    lockables[0].Unlock();
                    lockables.RemoveAt(0);
                }
                lockables.Add(present);
                present.Lock();
            }
        }
    }
}
