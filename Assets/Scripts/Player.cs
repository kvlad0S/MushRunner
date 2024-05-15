using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngineInternal;

public class Player : Core {


    
    [SerializeField] private PlayerAirState airState;
    [SerializeField] private PlayerGroundState groundState;
    [SerializeField] public InputHandler inputHandler;

    [SerializeField] public WallDetector wallDetector;

    Vector2 inputDir => inputHandler.GetInputDirection();


    private bool _isLookingRight = true;
    public bool IsLookingRight {
        get {
            return _isLookingRight;
        }
        private set {

            if (_isLookingRight != value) {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isLookingRight = value;

        }
    }

    private void Start() {
        machine = new StateMachine();
        SetupInstances();


        
        machine.Set(groundState);


    }

    private void Update() {
        HandleFacingDirection();
        SelectState();
        machine.state.DoBranch();
    }

    private void FixedUpdate() {
        machine.state.FixedDoBranch();
    }


    private void HandleFacingDirection() {

        if (wallDetector.isOnWall && !groundSensor.isGrounded) {
            if (wallDetector.IsWallDirectionRight() && !IsLookingRight) {
                IsLookingRight = true;
                Debug.Log(wallDetector.IsWallDirectionRight());
            } else if (wallDetector.IsWallDirectionRight() && IsLookingRight) {
                IsLookingRight = false;
                Debug.Log(wallDetector.IsWallDirectionRight());
            }
        } else {
            if (inputDir.x > 0 && !IsLookingRight) {
                IsLookingRight = true;
            } else if (inputDir.x < 0 && IsLookingRight) {
                IsLookingRight = false;
            }
        }
        
    }

 

    private void SelectState() {

        if(groundSensor.isGrounded) {
            machine.Set(groundState);
        } else {
            machine.Set(airState);
        }
    }
}

    



