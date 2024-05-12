using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : State {

    public override void Enter() {
        animator.Play(anim.name);
    }
    public override void FixedDo() {

    }
}
