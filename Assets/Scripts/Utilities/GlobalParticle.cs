using UnityEngine;

[CreateAssetMenu(menuName = "Spawners/Particle Spawner")]
public class GlobalParticle : ScriptableObject
{
    public ParticleSystem prefab;
    private ParticleSystem instance;

    private void OnDisable()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
    }

    public void Spawn(Vector3 position,int amount)
    {
        if(instance == null)
        {
            instance = Instantiate(prefab);
        }

        instance.transform.position = position;
        instance.Emit(amount);
    }
}
