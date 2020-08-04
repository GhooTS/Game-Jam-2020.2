using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class CharacterController2D : MonoBehaviour 
{
	
	[Header("Movement")]
	[Range(0f,.2f)]
	public float accelerationTimeAirborne = .02f;
	[Range(0f,.1f)]
	public float accelerationTimeGrounded = .01f;
	public float moveSpeed = 6;

	[Header("Jumping")]
	[Min(0)]
	public int maxJump = 2;
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;

	[Header("Wall Jumping")]
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;

	public bool Grounded { get { return controller.collisions.below && controller.collisions.fallingThroughPlatform == false; } }
	public bool Falling 
	{ 
		get 
		{
			return (controller.collisions.below == false || controller.collisions.fallingThroughPlatform) && velocity.y < 0;
		} 
	}
	public bool Jumping
    {
		get
		{
			return controller.collisions.below == false && velocity.y > 0;
		}
	}

	public Vector2 Velocity{ get; private set; }
	public bool Immobilaze { get; set; }



	float timeToWallUnstick;

	int jumpCount = 0;
	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	Vector2 directionalInput;
	bool wallSliding;
	int wallDirX;

	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
	}

	void FixedUpdate() {

		CalculateVelocity ();
		HandleWallSliding ();


		if (Immobilaze) 
		{
			velocity = Grounded ? Vector3.zero : new Vector3(0, Mathf.Min(0,velocity.y), velocity.z);
		}
		Velocity = velocity;

		controller.Move (velocity * Time.fixedDeltaTime, directionalInput);


		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.fixedDeltaTime;
			} else {
				velocity.y = 0;
			}
		}

        if (controller.collisions.below)
        {
			jumpCount = 0;
        }

	}

	public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
	}

	public void OnJumpInputDown() {
		if (wallSliding) {
			if (wallDirX == directionalInput.x) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (directionalInput.x == 0) {
				velocity.x = -wallDirX * wallJumpOff.x;
				velocity.y = wallJumpOff.y;
			}
			else {
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
			}
		}
		if (controller.collisions.below || jumpCount < maxJump) {
			if (controller.collisions.slidingDownMaxSlope) {
				if (directionalInput.x != -Mathf.Sign (controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
				}
				jumpCount++;
			}
			else {
				velocity.y = maxJumpVelocity;
				jumpCount++;
			}
		}
	}

	public void OnJumpInputUp() {
		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}
		

	void HandleWallSliding() {
		wallDirX = (controller.collisions.left) ? -1 : 1;
		wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;

			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (directionalInput.x != wallDirX && directionalInput.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				}
				else {
					timeToWallUnstick = wallStickTime;
				}
			}
			else {
				timeToWallUnstick = wallStickTime;
			}

		}

	}

	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
	}
}
