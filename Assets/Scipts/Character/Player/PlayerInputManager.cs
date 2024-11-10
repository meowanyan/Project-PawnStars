using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] public static PlayerInputManager Instance;

    [SerializeField] public PlayerInput playerInput;

    [SerializeField] public Vector2 moveInput;
    [SerializeField] public float verticalInput;
    [SerializeField] public float horizontalInput;
    [SerializeField] public float moveValue;




    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    //private void OnSceneChange(Scene oldScene, Scene newScene)
    //{
    //    if (newScene.buildIndex == TitleScreen.Instance.worldSceneIndex)
    //    {
    //        Instance.enabled = true;
    //    }
    //    else
    //    {
    //        Instance.enabled = false;
    //    }
    //}

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //Code runs on scene change
        //SceneManager.activeSceneChanged += OnSceneChange;

        //Instance.enabled = false;
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();

            playerInput.PlayerMovement.Keyboard.performed += i => moveInput = i.ReadValue<Vector2>();
        }

        playerInput.Enable();
    }

    private void OnDestroy()
    {
        //SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void Update()
    {
        RunMovementInput();
    }

    private void RunMovementInput()
    {
        verticalInput = moveInput.y;
        horizontalInput = moveInput.x;

        //returns the absolute value for movement input
        moveValue = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        //moveValue is either 0, 0.5 or 1 for smoother movement
        if (moveValue <=0.5 && moveValue > 0)
        {
            moveValue = 0.5f;
        }
        else if(moveValue > 0.5 && moveValue <= 1)
        {
            moveValue = 1;
        }
    }
}
