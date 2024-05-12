using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State {

    [SerializeField] private float jumpAnimationTimeScale = 20f;

    public override void Do() {
        float jumpTime = Helpers.Map(body.velocity.y, jumpAnimationTimeScale, 0f, 0f, 1f, true);
        animator.Play(anim.name, 0, jumpTime);
    }
}
