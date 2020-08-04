using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public Animator animator;
    public Health health;
    [Header("Events")]
    public UnityEvent onDeathAnimationEnded;

    private int dead;

    private void Start()
    {
        dead = Animator.StringToHash("Dead");
    }


    private void Update()
    {
        animator.SetBool(dead, !health.Alive);
    }

    private void DeadAnimationEnded()
    {
        onDeathAnimationEnded?.Invoke();
    }

}
