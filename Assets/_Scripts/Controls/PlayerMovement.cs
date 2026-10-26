using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    public CharacterController characterController;

    public float verticalVelocity;
    public Vector2 moveInput;

    void Start()
    {
        PlayerControls.Instance.AnnounceMove += OnMove;
    }

    void OnMove(Vector2 input)
    {
        moveInput = input;
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 movement = transform.right * moveInput.x
                           + transform.forward * moveInput.y;

        if (characterController.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;
        movement.y = verticalVelocity;

        characterController.Move(movement * moveSpeed * Time.deltaTime);
    }

    void OnDisable()
    {
        PlayerControls.Instance.AnnounceMove -= OnMove;
    }
}