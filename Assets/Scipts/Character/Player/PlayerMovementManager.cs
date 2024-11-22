using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : CharacterMovementManager
{
    [SerializeField] public PlayerManager player;
    [SerializeField] public GameObject playerObject;
    [SerializeField] public Camera playerView;

    [SerializeField] public float verticalMovement;
    [SerializeField] public float horizontalMovement;
    [SerializeField] public float moveValue;

    [SerializeField] public float verticalCameraMovement;
    [SerializeField] public float horizontalCameraMovement;

    [SerializeField] public Vector3 moveDirection;
    [SerializeField] public Vector2 turnDirection;
    [SerializeField] public Vector2 mousePos;

    [SerializeField] public RaycastHit selectInfo;

    [field:SerializeField] public float walkSpeed { get; private set; } = 2;
    [field:SerializeField] public float runSpeed { get; private set; } = 5;
    [Range (0f, 100f)]
    [SerializeField] float cameraSensitivity = 20;
    [field: SerializeField] public float clampValue { get; private set; } = 60;

    protected override void Awake()
    {
        //Awake function is overridden from Character Movement Manager
        base.Awake();

        player = GetComponent<PlayerManager>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        GroundMovement();
        PlayerLook();
    }

    private void GetMovementInputs()
    {
        verticalMovement = PlayerInputManager.Instance.verticalKeyInput;
        horizontalMovement = PlayerInputManager.Instance.horizontalKeyInput;
        verticalCameraMovement = PlayerInputManager.Instance.verticalMouseInput;
        horizontalCameraMovement = PlayerInputManager.Instance.horizontalMouseInput;
        mousePos += PlayerInputManager.Instance.mousePosition;
    }

    private void GroundMovement()
    {
        GetMovementInputs();
        //movement direction is based of player camera's perspective
        moveDirection = playerView.transform.forward * verticalMovement;
        moveDirection = moveDirection + playerView.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        //This to allow for walking and running if ever, default is running speed for now
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

    private void PlayerLook()
    {
        turnDirection += new Vector2(verticalCameraMovement, horizontalCameraMovement) * cameraSensitivity * Time.deltaTime;
        //This is to restrict the player's view range of looking up and down
        turnDirection.x = Mathf.Clamp(turnDirection.x, -clampValue, clampValue);

        //This is for moving the actual gameobject or camera
        playerObject.transform.rotation = Quaternion.Euler(-turnDirection.x, turnDirection.y, 0);

        Debug.DrawRay(playerView.transform.position, playerView.transform.forward * 10f, Color.green);

    }
}
