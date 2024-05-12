using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVisual : MonoBehaviour {


    [SerializeField] InputHandler inputHandler;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] private Animator animator;
    private Vector2 playerVelocity;
    private Vector2 lastPlayerVelocity = Vector2.zero;
    private Vector2 lastInputDir = Vector2.zero;




    private bool _isRunning = false;
    public bool IsRunning { 
        get { 
            return _isRunning;
        } 
        private set {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }


    private bool canStop = true;
    private void Update() {
       
        playerVelocity = playerRB.velocity;
        Vector2 inputDir = inputHandler.GetInputDirection();
        

        if (Mathf.Abs(playerVelocity.x) > 0) {
            IsRunning = true;
        } else if (playerVelocity.x == 0) {
            IsRunning = false;
        }

        if (Mathf.Abs(lastInputDir.x) < Mathf.Abs(inputDir.x)) {
            animator.ResetTrigger("stopRunning");
            animator.SetTrigger("startRunning");
            canStop = true;
        } else {
            if (inputDir == Vector2.zero && Mathf.Abs(playerVelocity.x) >= 0.5 && canStop) {
                animator.ResetTrigger("startRunning");
                animator.SetTrigger("stopRunning");
                canStop = false;
            }
            
        }

        lastPlayerVelocity = playerVelocity;
        lastInputDir = inputDir;
    }



}
