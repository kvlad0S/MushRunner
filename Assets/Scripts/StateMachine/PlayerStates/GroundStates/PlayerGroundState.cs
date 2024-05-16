using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerGroundState : State {

    [SerializeField] private PlayerRunState run;
    [SerializeField] private State idle;
    [SerializeField] private PlayerFallGroundState fallGround;
    [SerializeField] private Player player;
    [SerializeField] private float jumpSpeed = 20f;

    private bool isFalling;
    private Vector2 inputDir => player.inputHandler.GetInputDirection();


    public void Start() {
        fallGround.OnFallGroundEnd += OnFallGroundEnd;
    }

    

    public override void Enter()
    {
        if (inputDir == Vector2.zero) {
            Set(fallGround, true);
            isFalling = true;
        //} else {
            //run.isFastFalling = true;
        }
    }

    public override void Do() {
        if (fallGround.isComplete){
            isFalling = false;
        }
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
}
