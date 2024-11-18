using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : CharacterManager
{
    [SerializeField] public UnityEvent OnUpdate;

    //Whatever is scripted in CharacterManager may apply here + whatever stuff is needed for Player
    [SerializeField] public PlayerInputManager playerInputManager;
    [SerializeField] public PlayerMovementManager playerMovementManager;
    [SerializeField] public PlayerInteractionManager playerInteractionManager;

    protected override void Awake()
    {
        //Awake function is overridden from Character Manager
        base.Awake();

        playerMovementManager = GetComponent<PlayerMovementManager>();
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
    }

    protected override void Update()
    {
        //Update function is overridden from Character Manager
        base.Update();

        OnUpdate.Invoke();
    }


}
