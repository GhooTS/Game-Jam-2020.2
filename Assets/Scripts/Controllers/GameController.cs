using GTVariable;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class GameController : MonoBehaviour
{
    public Health player;
    [SerializeField]
    private FloatVariable currentTime;
    [SerializeField]
    private FloatVariable maxTime;
    public ResetableManager resetableManager;
    public Collider2D[] loopTriggers;
    public Transform startPoint;
    public bool LoopActive { get; private set; }
    public bool LoopPaused { get; private set; }
    public BoolVariable loopActive;
    public BoolVariable loopPaused;
    [Header("Events")]
    public UnityEvent onGameStarted;
    public UnityEvent onLoopStarted;
    public UnityEvent onLoopPaused;
    public UnityEvent onLoopResumed;
    public UnityEvent onLoopEnded;

    private void OnEnable()
    {
        onGameStarted?.Invoke();
        ResetTime();
    }



    private void Update()
    {
        loopActive.value = LoopActive;
        loopPaused.value = LoopPaused;
        
        if (LoopActive)
        {
            if(LoopPaused == false) currentTime.value -= Time.deltaTime;

            if (player.Alive == false || currentTime <= 0f)
            {
                EndLoop();
            }
        }

        if (player.Alive == false)
        {
            RespwanPlayer();
        }
    }

    public void StartLoop()
    {
        if (LoopActive) return;
        LoopActive = true;
        SetEnabledLoopTriggers(false);
        onLoopStarted?.Invoke();
    }

    public void PauseLoop()
    {
        LoopPaused = true;
        onLoopPaused?.Invoke();
    }

    public void ResumeLoop()
    {
        LoopPaused = false;
        onLoopResumed?.Invoke();
    }
    public void EndLoop()
    {
        if (LoopPaused)
        {
            ResumeLoop();
        }

        //Kill player
        player.Kill();
        //Respawn player
        RespwanPlayer();
        //Reset all objects
        resetableManager.ResetAll();
        //Set loop active to false
        LoopActive = false;
        //Restart timer
        ResetTime();
        //enabled loop start triggers
        SetEnabledLoopTriggers(true);
        onLoopEnded?.Invoke();
    }

    private void ResetTime()
    {
        currentTime.SetValue(maxTime);
    }

    public void RespwanPlayer()
    {
        //Move player to start position
        player.transform.position = startPoint.position;
        //Disable and enabled player to reset player state
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
