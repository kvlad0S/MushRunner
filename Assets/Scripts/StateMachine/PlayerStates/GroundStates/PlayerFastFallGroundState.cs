using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastFallGroundState : State {

    public event EventHandler OnFastFallGroundEnd;
    [SerializeField] private float fastFallTimerMax = .1f;
    private float fastFallTimer;

    public override void Enter() {
        animator.Play(anim.name);
        fastFallTimer = fastFallTimerMax;
    }

    public override void Do() {
        fastFallTimer -= Time.deltaTime;
        if (fastFallTimer <= 0f) {
            isComplete = true;
            OnFastFallGroundEnd?.Invoke(this, EventArgs.Empty);
        }
    }
}
