using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour {

    [SerializeField] BoxCollider2D groundDetector;
    [SerializeField] LayerMask groundMask;
    public bool isGrounded { get; private set; }


    private void FixedUpdate() {
        CheckGround();
    }
    public void CheckGround() {
        isGrounded = Physics2D.OverlapAreaAll(groundDetector.bounds.min, groundDetector.bounds.max, groundMask).Length > 0;
    }
}
