using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Controls;

[RequireComponent (typeof (CharacterController2D))]
[RequireComponent(typeof(AttackController))]
[RequireComponent (typeof (Health))]
[RequireComponent(typeof(PlayerInteraction))]
public class InputReader : MonoBehaviour 
{
	public bool PlayerInputEnabled { get; private set; } = true;
	private Health health;
	private CharacterController2D player;
	private AttackController attackController;
	private PlayerInteraction playerInteraction;
	private Vector2 directionalInput;

	void Start () {
		player = GetComponent<CharacterController2D> ();
		health = GetComponent<Health> ();
		attackController = GetComponent<AttackController>();
		playerInteraction = GetComponent<PlayerInteraction>();
	}

	void Update () 
	{
		player.SetDirectionalInput (directionalInput);
	}


	public void SetPlayerInputEnabled(bool enabled)
    {
		PlayerInputEnabled = enabled;
		directionalInput = Vector2.zero;
	}

	public void GetMoveDirection(InputAction.CallbackContext ctx)
    {
		if (PlayerInputEnabled == false) return;
		directionalInput = ctx.ReadValue<Vector2>();
    }

	public void Attack(InputAction.CallbackContext ctx)
	{
		if (PlayerInputEnabled == false) return;

		if (ctx.phase == InputActionPhase.Started)
		{
			attackController.Attack();
		}

	}

	public void Jump(InputAction.CallbackContext ctx)
    {
		if (PlayerInputEnabled == false) return;

		var control = ctx.control as ButtonControl;

		
        if (ctx.phase == InputActionPhase.Started && control.wasPressedThisFrame)
        {
			player.OnJumpInputDown();
        }
		if(ctx.phase == InputActionPhase.Canceled && control.wasReleasedThisFrame)
        {
			player.OnJumpInputUp();
        }
    }

	public void Interact(InputAction.CallbackContext ctx)
	{
		if (PlayerInputEnabled == false) return;

		if(ctx.phase == InputActionPhase.Started)
        {
			playerInteraction.Interact();
        }
    }

	public void ResetLoop(InputAction.CallbackContext ctx)
	{
		if (PlayerInputEnabled == false) return;

		var control = ctx.control as ButtonControl;

		if (ctx.phase == InputActionPhase.Started && control.wasPressedThisFrame)
		{
			health.Kill();
		}
	}
}
