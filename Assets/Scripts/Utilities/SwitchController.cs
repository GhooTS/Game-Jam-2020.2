using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField]
    private bool switchOn = false;
    [Header("Events")]
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;


    public void TurnOn()
    {
        onTurnOn?.Invoke();
    }

    public void TurnOff()
    {
        onTurnOff?.Invoke();
    }

    public void Switch()
    {
        if (switchOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }

        switchOn = !switchOn;
    }
}
