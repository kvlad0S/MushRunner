using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngineInternal;

public class Player : Core {


    
    [SerializeField] private PlayerAirState airState;
    [SerializeField] private PlayerGroundState groundState;
    [SerializeField] private PlayerFallState fallState;
    [SerializeField] public InputHandler inputHandler;
    [SerializeField] public FallDetector fallDetector;
    private bool justFalled => fallDetector.justFalled;

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
        Vector2 inputDir = inputHandler.GetInputDirection();

        if (inputDir.x > 0 && !IsLookingRight) {
            IsLookingRight = true;
        } else if (inputDir.x < 0 && IsLookingRight) {
            IsLookingRight = false;
        }
    }

 

    private void SelectState() {

        if(groundSensor.isGrounded && !fallState.IsOnFall && !justFalled) {
            machine.Set(groundState);
        } else if (!fallState.IsOnFall && !justFalled) {
            machine.Set(airState);
        } else if (justFalled || fallState.IsOnFall) {
            if (justFalled) {
                machine.Set(fallState, true);
                Debug.Log(justFalled);
            } else {
                machine.Set(fallState);
            }
            
        }
    }

    

}

