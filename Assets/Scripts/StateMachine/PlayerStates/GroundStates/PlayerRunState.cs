using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : State {


    [SerializeField] private State stopState;
    [SerializeField] private State runningState;
    //[SerializeField] private PlayerFastFallGroundState fastFall;
    //[SerializeField] float fastFallTimerMax = .5f;
    //private float fastFallTimer;
    //public bool isFastFalling;
    [SerializeField] float moveSpeed = 9f;

    
    [SerializeField] private Player player;
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();

    public void Start(){
        //fastFall.OnFastFallEnd += OnFastFallGroundEnd;
    }


    public override void Enter() {
        //if (isFastFalling) {
            //Set(fastFall, true);
       // }
        //fastFallTimer = fastFallTimerMax;
        
        
    }

    public override void FixedDo() {
        HandleMovement();
        //fastFallTimer -= Time.fixedDeltaTime;
        //if (fastFallTimer <= 0f){
            //isFastFalling = false;
        //}
        //Debug.Log(isFastFalling);
        //Debug.Log(fastFallTimer);
    }

    private void HandleMovement() {
        if (Mathf.Abs(inputDir.x) > 0) {
            body.velocity = new Vector2(inputDir.x * moveSpeed, body.velocity.y);
            //if (!isFastFalling){
                Set(runningState, true);
            //}

        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) > 0 && time >= 1f) {
            Set(stopState, true);
        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) > 0 && time < 1f) {
            body.velocity = new Vector2(0f, body.velocity.y);
        } else if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) == 0) {
            isComplete = true;
        }
    }

    //private void OnFastFallGroundEnd(object sender, EventArgs e)
    //{
    //    isFastFalling = false;
    //    Debug.Log("маму твою шатал");
   // }
}

