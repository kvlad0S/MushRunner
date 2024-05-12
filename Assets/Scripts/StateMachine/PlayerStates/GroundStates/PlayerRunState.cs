using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : State {


    [SerializeField] private State stopState;
    [SerializeField] private State runningState;
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] private Player player;
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();


    public override void Enter() {
        
    }

    public override void FixedDo() {
        HandleMovement();
    }

    private void HandleMovement() {
        if (Mathf.Abs(inputDir.x) > 0) {
            body.velocity = new Vector2(inputDir.x * moveSpeed, body.velocity.y);
            Set(runningState, true);
        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) > 0 && time >= 1f) {
            Set(stopState, true);
        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) > 0 && time < 1f) {
            body.velocity = new Vector2(0f, body.velocity.y);
        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) == 0) {
            isComplete = true;
        }
    }
}

