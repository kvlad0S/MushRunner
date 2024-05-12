using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : State {


    public override void Enter() {
        animator.Play(anim.name);
    }

}
