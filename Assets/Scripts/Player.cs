using System;
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

    public bool HasDashed { get; private set; }
    public bool IsDashing { get; private set; }

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

        inputHandler.OnDashed += OnDashed;

        groundState.dash.OnDashStart += OnDashStart;
        airState.dash.OnDashStart += OnDashStart;

        groundState.dash.OnDashStop += OnDashStop;
        airState.dash.OnDashStop += OnDashStop;
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

    private void OnDashed(object sender, EventArgs e) {
        HasDashed = true;
    }

    private void OnDashStop(object sender, EventArgs e) {
        HasDashed = false;
        IsDashing = false;
    }

    private void OnDashStart(object sender, EventArgs e) {
        IsDashing = true;
    }
}

    



