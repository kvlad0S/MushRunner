using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : State {

[SerializeField] private AnimationClip idle;
[SerializeField] private float idleTimerMax = 1f;
[SerializeField] private Player player;
private Vector2 inputDir => player.inputHandler.GetInputDirection();
[SerializeField] private float jumpSpeed = 20f;
[SerializeField] float moveSpeed = 9f;
[SerializeField] float wallDownSpeed = 10f;
private float idleTimer;


    public override void Enter()
    {
        animator.Play(idle.name);
        idleTimer = idleTimerMax;
    }

    public override void Do()
    {
        if (idleTimer >= 0) {
            idleTimer -= Time.deltaTime;
            if (inputDir.y == 0) {
                body.velocity = new Vector2(0f, 0f);
            }
            
        } else {
            animator.Play(anim.name);
            Vector2 wallVelocity = new Vector2(0f, body.velocity.y);
            wallVelocity.y = Mathf.Clamp(wallVelocity.y, -wallDownSpeed, 0f);
            body.velocity = wallVelocity;
        }
        if (inputDir.x > 0 && inputDir.y > 0f && !player.IsLookingRight) {
                body.velocity = new Vector2(inputDir.x * moveSpeed, inputDir.y * jumpSpeed);
            }
        else if(inputDir.x < 0 && inputDir.y > 0f && player.IsLookingRight){
            body.velocity = new Vector2(inputDir.x * moveSpeed, inputDir.y * jumpSpeed);
        }
        else if(Mathf.Abs(inputDir.x) == 0 && inputDir.y > 0){
            Vector2 wallAcceleration;
            if(player.IsLookingRight){
                wallAcceleration = new Vector2(-1f, 1f).normalized;
                body.velocity = new Vector2(wallAcceleration.x * moveSpeed, wallAcceleration.y * jumpSpeed);
            } else {
                wallAcceleration = new Vector2(1f, 1f).normalized;
                body.velocity = new Vector2(wallAcceleration.x * moveSpeed, wallAcceleration.y * jumpSpeed);
            }
        }
    }
}
