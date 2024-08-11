using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : State {
    [SerializeField] float dashSpeed = 40f;
    [SerializeField] float dashDeceleration = .9f;
    [SerializeField]private float dashAnimationTimeScale = 0.5f;
    [SerializeField] Player player;

    public event EventHandler OnDashStop;
    public event EventHandler OnDashStart;


    public override void Enter() {
        if (!player.IsDashing) {
            OnDashStart?.Invoke(this, EventArgs.Empty);
            if(player.IsLookingRight) {
                body.velocity = new Vector2(dashSpeed, 0);
            } else {
                body.velocity = new Vector2(-dashSpeed, 0);
            }
            
        }
        
    }

    public override void FixedDo() {
        body.velocity = new Vector2(body.velocity.x * dashDeceleration, 0);
    }

    public override void Do()
    {
        if(Mathf.Abs(body.velocity.x) < 5f){
            OnDashStop?.Invoke(this, EventArgs.Empty);
            isComplete = true;
        }

        float dashTime = Helpers.Map(Mathf.Abs(body.velocity.x), dashSpeed * dashAnimationTimeScale, 5f, 0f, 1f, true);
        animator.Play(anim.name, 0, dashTime);   
    }
}

