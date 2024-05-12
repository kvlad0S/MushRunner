using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {

    private Vector2 inputDir;


    public void OnMove(InputAction.CallbackContext context) {
        inputDir = context.ReadValue<Vector2>();
    }

    public Vector2 GetInputDirection() {
        return inputDir;
    }

}
