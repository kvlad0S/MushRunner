using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerGroundState : State {

    [SerializeField] private State run;
    [SerializeField] private State idle;
    [SerializeField] private Player player;
    [SerializeField] private float jumpSpeed = 20f;
    protected Vector2 inputDir => player.inputHandler.GetInputDirection();

    public override void Do() {
        if (isGrounded) {
            if (Mathf.Abs(inputDir.x) == 0 && Mathf.Abs(body.velocity.x) == 0) {
                Set(idle, true);
            } else if (Mathf.Abs(inputDir.x) > 0 || Mathf.Abs(body.velocity.x) > 0) {
                Set(run);
            }
            if (inputDir.y > 0) {
                body.velocity = new Vector2(body.velocity.x, inputDir.y * jumpSpeed);
            } 
        } else {
            isComplete = true;
        }
    }
}
