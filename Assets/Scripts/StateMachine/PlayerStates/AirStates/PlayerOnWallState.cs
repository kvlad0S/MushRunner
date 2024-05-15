using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : State {

[SerializeField] private AnimationClip idle;
[SerializeField] private float idleTimerMax = 1f;
private float idleTimer;


    public override void Enter()
    {
        animator.Play(idle.name);
        idleTimer = idleTimerMax;
        Debug.Log("WallState");
    }

    public override void Do()
    {
        if (idleTimer >= 0) {
            idleTimer -= Time.deltaTime;
            body.velocity = new Vector2(0f, 0f);
        } else {
            animator.Play(anim.name);
            body.velocity = new Vector2(0f,body.velocity.y);
        }
        
    }

}
