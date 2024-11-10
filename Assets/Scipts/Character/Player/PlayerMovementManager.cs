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
    [SerializeField] public float walkSpeed { get; private set; } = 2;
    [SerializeField] public float runSpeed { get; private set; } = 5;

    protected override void Awake()
    {
        //Awake function is overridden from Character Movement Manager
        base.Awake();

        player = GetComponent<PlayerManager>();
    }
    public void RunAllMovement()
    {
        GroundMovement();
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
}
