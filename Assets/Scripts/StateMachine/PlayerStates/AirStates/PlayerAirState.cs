using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : State {


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float downSpeedScale = 1.1f;
    [SerializeField] private float upSpeedScale = 0.96f;
    [SerializeField] private float maxFallingSpeed = 15f;
    [SerializeField] private Player player;
    [SerializeField] private State jump;
    [SerializeField] private State startFalling;
    [SerializeField] private State falling;
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();
    [SerializeField] private float fallingAnimEndSpeed = 6f;

    public override void Enter() {
   
    }

    public override void Do() {
        float jumpXSpeed;
        
        if (Mathf.Abs(inputDir.x) > 0f) {
            jumpXSpeed = (Mathf.Abs(body.velocity.x) > Mathf.Abs(inputDir.x * moveSpeed) && body.velocity.x * inputDir.x > 0) ? body.velocity.x : inputDir.x * moveSpeed;

            body.velocity = new Vector2(jumpXSpeed, body.velocity.y);
        } else {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        }

        if (body.velocity.y > 0) {
            Set(jump);
        } else if (body.velocity.y <= 0f && body.velocity.y > -fallingAnimEndSpeed) {
            Set(startFalling);
        } else if (body.velocity.y <= -fallingAnimEndSpeed) {
            Set(falling);
        }
        if (body.velocity.y < 0 && isGrounded) {
            Debug.Log("Fall");
        }
        

        
    }

    public override void FixedDo() {
        float jumpYSpeed;

        if (body.velocity.y > 0) {
            jumpYSpeed = body.velocity.y * upSpeedScale;
            jumpYSpeed = Mathf.Clamp(jumpYSpeed, 0f, maxFallingSpeed);
            body.velocity = new Vector2(body.velocity.x, jumpYSpeed);
        }

        if (body.velocity.y < 0) {
            jumpYSpeed = body.velocity.y * downSpeedScale;
            jumpYSpeed = Mathf.Clamp(jumpYSpeed, -maxFallingSpeed, 0f);
            body.velocity = new Vector2(body.velocity.x, jumpYSpeed);
        }
    }

    public override void Exit() {

    }
}
