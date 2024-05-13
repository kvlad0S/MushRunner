using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerGroundState : State {

    [SerializeField] private State run;
    [SerializeField] private State idle;
    [SerializeField] private PlayerFallGroundState fallGround;
    [SerializeField] private PlayerFastFallGroundState fastFallGround;
    [SerializeField] private Player player;
    [SerializeField] private float jumpSpeed = 20f;

    private bool isFalling;
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();


    public void Start() {
        fallGround.OnFallGroundEnd += OnFallGroundEnd;
        fastFallGround.OnFastFallGroundEnd += OnFastFallGroundEnd;
    }

    

    public override void Enter()
    {
        if (inputDir.y == 0f) {
            Set(fallGround, true);
            isFalling = true;
        } else if (inputDir.y > 0f) {
            Set(fastFallGround, true);
            isFalling = true;
        }
    }

    public override void Do() {
        if (isGrounded && !isFalling) {
            if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) == 0) {
                Set(idle, true);
            } else if (Mathf.Abs(inputDir.x) > 0 || Mathf.Abs(body.velocity.x) > 0) {
                Set(run);
            }
            if (inputDir.y > 0) {
                body.velocity = new Vector2(body.velocity.x, inputDir.y * jumpSpeed);
            } 
        } else {
            isComplete = true;
        }
    }

    private void OnFallGroundEnd(object sender, System.EventArgs e) {
        isFalling = false;
    }
    
    private void OnFastFallGroundEnd(object sender, EventArgs e)
    {
        isFalling = false;
    }
}
