using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerFallState : State {


    [SerializeField] private PlayerFallGroundState fallGroundState;
    [SerializeField] private PlayerFastFallGroundState fastFallGroundState;
    [SerializeField] private Player player;
    public bool IsOnFall {  get; private set; }
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();

    public override void Enter() {
        IsOnFall = true;
        if (inputDir.y > 0) {
            Set(fastFallGroundState, true);
        } else {
            Set(fallGroundState, true);
        }
        
    }

    public override void Do() { 
        if (fastFallGroundState.isComplete || fallGroundState.isComplete) {
            IsOnFall = false;
        }
    }
}

