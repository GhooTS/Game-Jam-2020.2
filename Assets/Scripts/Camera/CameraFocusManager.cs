using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Managers/Camera Manager",fileName = "Camera Manager")]
public class CameraFocusManager : ScriptableObject
{
    public ManageableCamera Current { private get; set; }
    public UnityEvent onCameraFocus;
    public UnityEvent onCameraLoseFocus;

    private readonly Queue<FocusableTarget> targetsQueue = new Queue<FocusableTarget>();
    public bool TargetFocus { get; private set; } = false;


    private void OnEnable()
    {
        TargetFocus = false;
    }

    public void QueueFocus(FocusableTarget target)
    {
        if (TargetFocus == false)
        {
            Focus(target);
        }
        else
        {
            targetsQueue.Enqueue(target);
        }
    }

    public void Focus(FocusableTarget target)
    {
        TargetFocus = true;
        Current.Focus(target.transform);
        target.StartFocus();
        onCameraFocus?.Invoke();
    }

    public void LoseFocus()
    {
        if (targetsQueue.Count != 0)
        {
            Focus(targetsQueue.Dequeue());
        }
        else
        {
            Current.LoseFocus();
            onCameraLoseFocus?.Invoke();
            TargetFocus = false;
        }
    }
}
