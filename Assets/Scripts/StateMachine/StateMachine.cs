using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine {
    public State state;



    public void Set(State newState, bool forceReset = false) {
        if (state != newState || forceReset) {
            state?.Exit();
            state = newState;
            state.Initialize(this);
            state.Enter();
        }
    }
}

