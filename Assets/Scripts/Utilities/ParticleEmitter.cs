using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public GlobalParticle particle;


    public void Emit(int amount)
    {
        particle.Spawn(transform.position, amount);
    }
}
