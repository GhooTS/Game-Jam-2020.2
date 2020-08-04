using GTVariable;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public FloatReference HP;
    public FloatReference MaxHP;
    [Header("Events")]
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath;

    public bool Alive { get; private set; } = false;

    private void OnEnable()
    {
        Restard();
    }

    public void Restard()
    {
        HP.Value = MaxHP.Value;
        Alive = true;
    }

    public void Restard(float HP)
    {
        this.HP.Value = Mathf.Min(HP,MaxHP);
        Alive = true;
    }

    public void TakeDamage(float damage)
    {
        if(Alive)
        {
            HP.Value -= damage;
            OnDamaged?.Invoke();
            TryKill();
        }
    }

    private void TryKill()
    {
        if (HP.Value <= 0f) 
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (Alive == false) return;

        if(HP.Value > 0)
        {
            HP.Value -= HP.Value;
            OnDamaged?.Invoke();
        }
        Alive = false;
        OnDeath?.Invoke();
    }
}
