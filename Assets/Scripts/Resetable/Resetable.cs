﻿using GTVariable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class Resetable : MonoBehaviour
{
    public bool resetPosition = true;
    public Lockable lockable;
    public UnityEvent onRestard;

    private Vector3 savePosition;

    private void Start()
    {
        savePosition = transform.position;
    }


    [ContextMenu("ResetState")]
    public void ResetState()
    {
        if (lockable != null && lockable.IsLock) return;

        transform.position = savePosition;
        onRestard?.Invoke();
    }
}
