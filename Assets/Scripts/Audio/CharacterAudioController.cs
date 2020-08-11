using TMPro;
using UnityEngine;

public class CharacterAudioController : MonoBehaviour
{

    public void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

    public void PlayFootstepSound(string path)
    {
        PlaySound(path);
    }

    public void PlayAttackSound(string path)
    {
        PlaySound(path);
    }
}
