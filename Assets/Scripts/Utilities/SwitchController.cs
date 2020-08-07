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


    private void Start()
    {
        if (switchOn) TurnOn();
        else TurnOff();
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
}
