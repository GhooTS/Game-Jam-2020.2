using FMODUnity;
using UnityEngine;
using UnityEngine.Events;


public class SwitchController : MonoBehaviour
{
    [SerializeField]
    private bool switchOn = false;
    public bool invert = false;
    public SwitchController[] switches;
    [Header("Events")]
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;
    public UnityEvent onSetInitalState;


    private void Start()
    {
        SetInitalState();
    }

    public void TurnOn()
    {
        onTurnOn?.Invoke();
        foreach (var switchController in switches)
        {
            switchController.TurnOn();
        }
    }

    public void TurnOff()
    {
        onTurnOff?.Invoke();
        foreach (var switchController in switches)
        {
            switchController.TurnOff();
        }
    }

    public void Switch()
    {
        if (switchOn == !invert)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }

        switchOn = !switchOn;
    }

    public void SetInitalState()
    {
        onSetInitalState?.Invoke();
    }

}
