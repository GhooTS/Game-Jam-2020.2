using UnityEngine;

[RequireComponent(typeof(IDamageable))]
[RequireComponent(typeof(CharacterController2D))]
public class FallDamage : MonoBehaviour
{
    [Min(0f)]
    public float timeThreshold;
    [Min(0f)]
    public float maxTime;
    [Min(0f)]
    public float maxDamage;
    public AnimationCurve damageCurve;

    private IDamageable damageable;
    private CharacterController2D characterController;
    private float inAirTime;


    private void Start()
    {
        damageable = GetComponent<IDamageable>();
        characterController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if(characterController.Velocity.y > 0)
        {
            inAirTime = 0;
        }

        if (characterController.Grounded)
        {
            if (inAirTime < timeThreshold)
            {
                inAirTime = 0f;
            }
            else
            {
                var damage = maxDamage * damageCurve.Evaluate(Mathf.Min(1, Mathf.Abs(inAirTime / maxTime)));
                damage = Mathf.Round(damage);
                damageable.TakeDamage(damage);
                Debug.Log($"Fall damage: {damage} with speed of {inAirTime}");
                inAirTime = 0;
            }
        }
        else
        {
            inAirTime += Time.deltaTime;
        }
    }
}
