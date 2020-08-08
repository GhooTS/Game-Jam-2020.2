using GTVariable;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class GameController : MonoBehaviour
{
    public Health player;
    public TimeController timeController;
    public ResetableManager resetableManager;
    public Collider2D[] loopTriggers;
    public Transform startPoint;
    public bool LoopActive { get; private set; }
    public BoolVariable loopActive;
    public UnityEvent onGameStarted;


    private void OnEnable()
    {
        timeController.timeRunOut.AddListener(ResetLoop);
    }

    private void OnDisable()
    {
        timeController.timeRunOut.RemoveListener(ResetLoop);
    }


    private void Update()
    {
        loopActive.value = LoopActive;
        if(player.Alive == false)
        {
            ResetLoop();
        }

    }

    public void StartLoop()
    {
        if (LoopActive) return;
        LoopActive = true;
        
        timeController.StartTime();
        SetEnabledLoopTriggers(false);
    }

    public void ResetLoop()
    {
        player.Kill();
        RespwanPlayer();
        resetableManager.ResetAll();
        LoopActive = false;
        SetEnabledLoopTriggers(true);
        timeController.StopTime();
        timeController.ResetTimer();
    }

    public void RespwanPlayer()
    {
        player.transform.position = startPoint.position;
        player.gameObject.SetActive(false);
        player.gameObject.SetActive(true);

    }

    private void SetEnabledLoopTriggers(bool enabled)
    {
        foreach (var loopTrigger in loopTriggers)
        {
            loopTrigger.enabled = enabled;
        }
    }
}
