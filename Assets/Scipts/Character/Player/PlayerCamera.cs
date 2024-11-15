using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public static PlayerCamera Instance;

    [SerializeField] public Camera playerView;

    [SerializeField] public float verticalCameraMovement;
    [SerializeField] public float horizontalCameraMovement;
    [SerializeField] public float rotateValue;
    [SerializeField] public float cameraSensitivity;

    private void Awake()
    {
        if (Instance == null) {Instance = this;}
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void GetMouseInput()
    {
        verticalCameraMovement = PlayerInputManager.Instance.verticalMouseInput;

    }
}
