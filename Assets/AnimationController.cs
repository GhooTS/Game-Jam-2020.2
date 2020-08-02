using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
	public Player player;
    public Animator animator;
    public SpriteRenderer characterRenderer;


    private int speed;
    private int jump;
    private int fall;

    private void Start()
    {
        speed = Animator.StringToHash("Speed");
        jump = Animator.StringToHash("Jump");
        fall = Animator.StringToHash("Fall");
    }


    private void Update()
    {
        animator.SetBool(fall, player.Falling);
        animator.SetBool(jump, player.Jumping);
        animator.SetFloat(speed, Mathf.Abs(player.MoveSpeed));
        if(player.MoveSpeed != 0) characterRenderer.flipX = Mathf.Sign(player.MoveSpeed) == -1f ? true : false;
    }
}