using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] public CharacterController characterController;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this); 

        characterController = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {

    }
}
