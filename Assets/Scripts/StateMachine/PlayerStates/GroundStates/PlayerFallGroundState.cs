using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallGroundState : State {

    public event EventHandler OnFallGroundEnd;
    [SerializeField] private float fallTimerMax = .25f;
    [SerializeField] private Player player;
    private Vector2 inputDir => player.inputHandler.GetInputDirection();

    private float fallTimer;


    public override void Enter() {
        animator.Play(anim.name);
        fallTimer = fallTimerMax;
        body.velocity = Vector2.zero;
    }

    public override void Do() {
        fallTimer -= Time.deltaTime;
        if (fallTimer <= 0f) {
            isComplete = true;
            OnFallGroundEnd?.Invoke(this, EventArgs.Empty);
        }
        if (inputDir != Vector2.zero){
            isComplete = true;
        }
    }
}