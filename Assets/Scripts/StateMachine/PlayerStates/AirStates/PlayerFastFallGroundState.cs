using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastFallGroundState : State {

    [SerializeField] private float fastFallTimerMax = .25f;

    public override void Enter() {
        animator.Play(anim.name);
        body.velocity = Vector3.zero;
    }

    public override void FixedDo() {
        if (time > fastFallTimerMax) {
            isComplete = true;
        }
    }
}
