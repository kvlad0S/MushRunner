using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerGroundState : State {

    [SerializeField] private PlayerRunState run;
    [SerializeField] private State idle;
    [SerializeField] private PlayerFallGroundState fallGround;
    [SerializeField] private PlayerDashState dash;
    [SerializeField] private Player player;
    [SerializeField] private float jumpSpeed = 20f;

    private bool isFalling;
    private bool isDashing;
    private Vector2 inputDir => player.inputHandler.GetInputDirection();


    public void Start() {
        fallGround.OnFallGroundEnd += OnFallGroundEnd;
        player.inputHandler.OnDashed += OnDashed;
    }

    

    public override void Enter()
    {
        if (inputDir == Vector2.zero) {
            Set(fallGround, true);
            isFalling = true;
        }
        isDashing = false;
    }

    public override void Do() {
        if (dash.isComplete) {
            isDashing = false;
            isFalling = false;
        }
        if (fallGround.isComplete){
            isFalling = false;
        }
        if (isGrounded && !isFalling && !isDashing) {
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

    private void OnDashed(object sender, System.EventArgs e) {
        if(!isDashing && isGrounded){
            isDashing = true;
            Set(dash, true);
        }
    }
}
