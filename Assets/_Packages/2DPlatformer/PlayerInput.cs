using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Controls;

[RequireComponent (typeof (CharacterController2D))]
[RequireComponent (typeof (Health))]
public class PlayerInput : MonoBehaviour {

	Health health;
	CharacterController2D player;
	private Vector2 directionalInput;

	void Start () {
		player = GetComponent<CharacterController2D> ();
		health = GetComponent<Health> ();
	}

	void Update () {
		player.SetDirectionalInput (directionalInput);
	}


	public void GetMoveDirection(InputAction.CallbackContext ctx)
    {
		directionalInput = ctx.ReadValue<Vector2>();
    }

	public void Jump(InputAction.CallbackContext ctx)
    {
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

	public void ResetLoop(InputAction.CallbackContext ctx)
	{
		var control = ctx.control as ButtonControl;

		if (ctx.phase == InputActionPhase.Started && control.wasPressedThisFrame)
		{
			health.Kill();
		}
	}
}
