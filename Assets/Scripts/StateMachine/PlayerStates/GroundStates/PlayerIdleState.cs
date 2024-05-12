using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State {


    

    public override void Enter() {
        animator.Play(anim.name);
    }

    public override void Do() {
        //Do PlayerStoppingState
        body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
    }

    public override void Exit() {

    }
}

