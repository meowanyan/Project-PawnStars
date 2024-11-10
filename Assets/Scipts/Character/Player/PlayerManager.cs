using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    //Whatever is scripted in CharacterManager may apply here + whatever stuff is needed for Player
    [SerializeField] public PlayerMovementManager playerMovementManager;
    protected override void Awake()
    {
        //Awake function is overridden from Character Manager
        base.Awake();

        playerMovementManager = GetComponent<PlayerMovementManager>();
    }

    protected override void Update()
    {
        //Update function is overridden from Character Manager
        base.Update();

        //Runs all movement of the player every frame
        playerMovementManager.RunAllMovement();
    }
}
