using UnityEngine;

public class PlayerRespanw : MonoBehaviour
{
    public CharacterController2D player;


    public void Respawn()
    {
        player.transform.position = transform.position;
        player.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }
}
