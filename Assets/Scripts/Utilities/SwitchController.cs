using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : Switchable
{
    public Sprite onSprite;
    public Sprite offSprite;
    public SpriteRenderer spriteRenderer;
    [Header("Events")]
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;
    public UnityEvent onSetInitialState;

    public bool SwitchOn { get; private set; }

    private void Start()
    {
        SetInitialState();
    }

    public override void Switch()
    {
        Switch(!SwitchOn);
    }

    public override void Switch(bool switchOn)
    {
        spriteRenderer.sprite = switchOn ? onSprite : offSprite;
        if (switchOn)
        {
            onTurnOn?.Invoke();
        }
        else
        {
            onTurnOff?.Invoke();
        }
        SwitchOn = switchOn;
    }

    public override void SetInitialState()
    {
        spriteRenderer.sprite = defualtState ? onSprite : offSprite;
        SwitchOn = defualtState;
        onSetInitialState?.Invoke();
    }

}
