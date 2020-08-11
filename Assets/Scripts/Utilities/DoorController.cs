using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class DoorController : Switchable
{

    public Sprite openSprite;
    public Sprite closeSprite;
    public SpriteRenderer doorRenderer;
    public Collider2D doorCollider;
    [Header("Events")]
    public UnityEvent onOpen;
    public UnityEvent onClose;
    public UnityEvent onSetInitialState;

    public bool IsOpen { get; private set; }

    private void Start()
    {
        SetInitialState();
    }

    public void Open()
    {
        IsOpen = false;
        Switch();
    }

    public void Close()
    {
        IsOpen = true;
        Switch();
    }

    public override void Switch()
    {
        Switch(!IsOpen);
    }

    public override void Switch(bool open)
    {
        if (open == IsOpen) return;

        doorRenderer.sprite = open ? openSprite : closeSprite;
        doorCollider.enabled = !open;
        IsOpen = open;

        if (IsOpen)
        {
            onOpen?.Invoke();
        }
        else
        {
            onClose?.Invoke();
        }
    }

    public override void SetInitialState()
    {
        doorRenderer.sprite = defualtState ? openSprite : closeSprite;
        doorCollider.enabled = !defualtState;
        IsOpen = defualtState;
    }
}
