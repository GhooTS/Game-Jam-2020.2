using UnityEngine;

public class DealDamageTrigger : MonoBehaviour
{
    public string colliderTag;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(colliderTag) && collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }
}