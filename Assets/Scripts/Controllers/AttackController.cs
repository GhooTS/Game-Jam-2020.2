using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AttackController : MonoBehaviour
{
    public Vector2 attackPoint;
    public float radius;
    public float damage;
    public string ignoreTag;
    public Animator animator;
    private int attack;
    private int dead;
    private int flip;


    public void Start()
    {
        attack = Animator.StringToHash("Attack");
        dead = Animator.StringToHash("Dead");
        flip = Animator.StringToHash("Flip");
    }

    public void Attack()
    {
        if (animator.GetBool(dead)) return;

        if (animator.GetCurrentAnimatorStateInfo(0).tagHash != attack)
        {
            animator.SetTrigger(attack);
            
        }
    }

    public void DealDamage()
    {
        var attackPosition = (Vector2)transform.position + attackPoint * (animator.GetBool(flip) ? -1 : 1);
        var targets = Physics2D.OverlapCircleAll(attackPosition, radius);
        foreach (var target in targets)
        {
            if (!target.CompareTag(ignoreTag) && target.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + attackPoint, radius);
    }
}
