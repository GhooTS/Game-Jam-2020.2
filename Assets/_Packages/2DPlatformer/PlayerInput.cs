using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Controls;

[RequireComponent (typeof (CharacterController2D))]
public class PlayerInput : MonoBehaviour {

	CharacterController2D player;
	private Vector2 directionalInput;

	void Start () {
		player = GetComponent<CharacterController2D> ();
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
}
