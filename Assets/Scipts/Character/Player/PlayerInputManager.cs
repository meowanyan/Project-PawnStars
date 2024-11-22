using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] public static PlayerInputManager Instance;

    [SerializeField] public PlayerInput playerInput;

    [SerializeField] public UnityEvent OnClick;

    //WASD keyboard movement
    [SerializeField] public Vector2 moveInput;
    [SerializeField] public float verticalKeyInput;
    [SerializeField] public float horizontalKeyInput;
    [SerializeField] public float moveValue;

    //Mouse rotation
    [SerializeField] public Vector2 mouseInput;
    [SerializeField] public Vector2 mousePosition;
    [SerializeField] public float verticalMouseInput;
    [SerializeField] public float horizontalMouseInput;

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

            playerInput.PlayerMovement.Walk.performed += i => moveInput = i.ReadValue<Vector2>();
            playerInput.PlayerLook.LookAround.performed += i => mouseInput = i.ReadValue<Vector2>();
            playerInput.PlayerLook.MousePosition.performed += i => mousePosition = i.ReadValue<Vector2>();
            playerInput.PlayerLook.Inspection.performed += RunMouseClick;

        }

        playerInput.Enable();
    }

    private void OnDestroy()
    {
        //SceneManager.activeSceneChanged -= OnSceneChange;
    }

    public void Update()
    {
        RunMovementInput();
        RunMouseInput();
    }

    private void RunMovementInput()
    {
        verticalKeyInput = moveInput.y;
        horizontalKeyInput = moveInput.x;

        //returns the absolute value for movement input
        moveValue = Mathf.Clamp01(Mathf.Abs(verticalKeyInput) + Mathf.Abs(horizontalKeyInput));

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

    private void RunMouseInput()
    {
        verticalMouseInput = mouseInput.y;
        horizontalMouseInput = mouseInput.x;
    }

    private void RunMouseClick(InputAction.CallbackContext context)
    {
        OnClick.Invoke();
    }
}
