using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public static PlayerCamera Instance;

    private void Awake()
    {
        if (Instance == null) {Instance = this;}
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
