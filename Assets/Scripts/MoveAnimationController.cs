﻿using UnityEngine;
using UnityEngine.Events;

public class MoveAnimationController : MonoBehaviour
{
	public CharacterController2D player;
    public Animator animator;
    public SpriteRenderer characterRenderer;


    //hash codes
    private int speed;
    private int jump;
    private int fall;
    private int grounded;
    private int attack;


    private void Start()
    {
        speed = Animator.StringToHash("Speed");
        jump = Animator.StringToHash("Jump");
        fall = Animator.StringToHash("Fall");
        grounded = Animator.StringToHash("Grounded");
        attack = Animator.StringToHash("Attack");
    }


    private void Update()
    {

        animator.SetBool(fall, player.Falling);
        animator.SetBool(jump, player.Jumping);
        animator.SetFloat(speed, Mathf.Abs(player.Velocity.x));
        animator.SetBool(grounded, player.Grounded);
        player.Immobilaze = animator.GetCurrentAnimatorStateInfo(0).tagHash == attack;

        if(player.Velocity.x != 0) characterRenderer.flipX = Mathf.Sign(player.Velocity.x) == -1f;
    }


    
}