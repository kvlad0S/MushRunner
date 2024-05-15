using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallGroundState : State {

    public event EventHandler OnFallGroundEnd;
    [SerializeField] private float fallTimerMax = .25f;
    private float fallTimer;


    public override void Enter() {
        animator.Play(anim.name);
        body.velocity = Vector3.zero;
        fallTimer = fallTimerMax;
    }

    public override void Do() {
        fallTimer -= Time.deltaTime;
        if (fallTimer <= 0f) {
            isComplete = true;
            OnFallGroundEnd?.Invoke(this, EventArgs.Empty);
        }
    }
}