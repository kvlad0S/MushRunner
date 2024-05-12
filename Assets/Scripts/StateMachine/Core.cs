using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D body;
    
    public StateMachine machine;
    
    public GroundSensor groundSensor;

    public void SetupInstances() {
        machine = new StateMachine();
        State[] allChildStates = GetComponentsInChildren<State>();
        foreach (State state in allChildStates) {
            state.SetCore(this);
        }
    }

}

