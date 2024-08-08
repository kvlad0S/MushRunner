using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {

    public event EventHandler OnDashed;

    private Vector2 inputDir;


    public void OnMove(InputAction.CallbackContext context) {
        inputDir = context.ReadValue<Vector2>();
    }

    public Vector2 GetInputDirection() {
        return inputDir;
    }

    public void OnDash(InputAction.CallbackContext context) {
        OnDashed?.Invoke(this, EventArgs.Empty);
    }

}
