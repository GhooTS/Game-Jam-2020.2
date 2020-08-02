using UnityEngine;

public class MoveController : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 10f;
    private float moveDirection;
    private bool jump;


    private void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        controller.Move(moveDirection * moveSpeed * Time.fixedDeltaTime,false,jump);
    }
}
