using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : State {
    [SerializeField] float dashSpeed = 40f;
    [SerializeField] float dashDeceleration = .9f;
    [SerializeField]private float dashAnimationTimeScale = 20f;
    [SerializeField] Player player;

    public override void Enter() {
        if(player.IsLookingRight){
            body.velocity = new Vector2(dashSpeed, 0);
        } else{
            body.velocity = new Vector2(-dashSpeed, 0);
        }
    }

    public override void FixedDo() {
        if(Mathf.Abs(body.velocity.x) < 1f){
            isComplete = true;
        } else {
            body.velocity = new Vector2(body.velocity.x * dashDeceleration, 0);
        }
    }

    public override void Do()
    {
        float dashTime = Helpers.Map(Mathf.Abs(body.velocity.x), dashAnimationTimeScale, 0f, 0f, 1f, true);
        animator.Play(anim.name, 0, dashTime);   
    }
}

