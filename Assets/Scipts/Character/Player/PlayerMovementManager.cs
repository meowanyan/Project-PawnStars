using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : CharacterMovementManager
{
    [SerializeField] public PlayerManager player;

    [SerializeField] public float verticalMovement;
    [SerializeField] public float horizontalMovement;
    [SerializeField] public float moveValue;

    [SerializeField] public Vector3 moveDirection;
    [SerializeField] public Vector3 viewDirection;

    [SerializeField] public float moveSpeed;
    [field:SerializeField] public float rotationSpeed { get; private set; } = 0.1f;
    [field:SerializeField] public float walkSpeed { get; private set; } = 2;
    [field:SerializeField] public float runSpeed { get; private set; } = 5;

    protected override void Awake()
    {
        //Awake function is overridden from Character Movement Manager
        base.Awake();

        player = GetComponent<PlayerManager>();
    }
    public void RunAllMovement()
    {
        GroundMovement();
        RotationMovement();
    }

    private void GetMovementInputs()
    {
        verticalMovement = PlayerInputManager.Instance.verticalInput;
        horizontalMovement = PlayerInputManager.Instance.horizontalInput;
    }

    private void GroundMovement()
    {
        GetMovementInputs();
        //movement direction is based of player camera's perspective
        moveDirection = PlayerCamera.Instance.transform.forward * verticalMovement;
        moveDirection = moveDirection + PlayerCamera.Instance.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerInputManager.Instance.moveValue > 0.5f)
        {
            //running speed
            player.characterController.Move(moveDirection * runSpeed * Time.deltaTime);
        }
        else if (PlayerInputManager.Instance.moveValue <= 0.5f)
        {
            //walking speed
            player.characterController.Move(moveDirection * walkSpeed * Time.deltaTime);
        }
    }

    private void RotationMovement()
    {
        viewDirection = Vector3.zero;
        viewDirection = PlayerCamera.Instance.playerView.transform.forward * verticalMovement;
        viewDirection = viewDirection + PlayerCamera.Instance.transform.right * horizontalMovement;
        viewDirection.Normalize();
        viewDirection.y = 0;

        if (viewDirection == Vector3.zero)
        {
            viewDirection = transform.forward;
        }

        Quaternion newRotation = Quaternion.LookRotation(viewDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }
}
