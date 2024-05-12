using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallGroundState : State {


    [SerializeField] private float fallTimerMax = .3f;


    public override void Enter() {
        animator.Play(anim.name);
        body.velocity = Vector3.zero;
    }

    public override void FixedDo() {
        if (time > fallTimerMax) {
            isComplete = true;
        }
    }


}