using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AttackController : MonoBehaviour
{
    public Animator animator;
    private int attack;


    public void Start()
    {
        attack = Animator.StringToHash("Attack");
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        var button = ctx.control as ButtonControl;

        if (ctx.phase == InputActionPhase.Started && button.wasPressedThisFrame && animator.GetCurrentAnimatorStateInfo(0).tagHash != attack)
        {
            animator.SetTrigger(attack);
        }
    }
}
