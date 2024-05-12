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
        if (player.justFalled) {
            IsOnFall = true;
        }
        
        if (Mathf.Abs(inputDir.y) > 0) {
            Set(fastFallGroundState);
        } else {
            Set(fallGroundState);
        }
        
    }

    public override void Do() { 
        if (fastFallGroundState.isComplete || fallGroundState.isComplete) {
            IsOnFall = false;
        }
    }
}

