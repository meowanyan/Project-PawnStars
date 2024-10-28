using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;

    PlayerInput playerInput;

    [SerializeField] Vector2 moveInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }

        //Code runs on scene change
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    private void OnSceneChange(Scene oldScene, Scene newScene)
    {
        if (newScene.buildIndex == TitleScreen.Instance.worldSceneIndex)
        {
            Instance.enabled = true;
        }
        else
        {
            Instance.enabled = false;
        }
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();

            playerInput.PlayerMovement.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
        }

        playerInput.Enable();
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }
}
