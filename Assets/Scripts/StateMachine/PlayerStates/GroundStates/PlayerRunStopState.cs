using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunStopState : State {


    [SerializeField] private float stoppingSpeed = 0.9f;

    public override void Enter() {
        animator.Play(anim.name);
    }

    public override void FixedDo() {
        body.velocity = new Vector2(body.velocity.x * stoppingSpeed, body.velocity.y);
    }

}

