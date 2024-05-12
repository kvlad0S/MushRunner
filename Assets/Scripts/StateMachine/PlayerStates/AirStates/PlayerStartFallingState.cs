using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartFallingState : State {

    [SerializeField] private float fallingAnimEndSpeed = 6f;


    public override void Do() {
        float jumpTime = Helpers.Map(body.velocity.y, 0f, -fallingAnimEndSpeed, 0f, 1f, true);
        animator.Play(anim.name, 0, jumpTime);
    }
}
