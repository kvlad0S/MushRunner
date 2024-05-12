using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastFallGroundState : State {

    [SerializeField] private float fastFallTimerMax = .1f;
    private float fastFallTimer;

    public override void Enter() {
        animator.Play(anim.name);
        body.velocity = Vector3.zero;
        fastFallTimer = fastFallTimerMax;
    }

    public override void Do() {
        fastFallTimer -= Time.deltaTime;
        if (fastFallTimer <= 0f) {
            isComplete = true;
            Debug.Log("fastFallState");
        }
    }
}
