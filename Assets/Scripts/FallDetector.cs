using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour {

    [SerializeField] private Collider2D fallDetector;
    [SerializeField] LayerMask groundMask;
    

    public bool justFalled { get; private set; }

    public void FixedUpdate() {
        CheckFalling();
    }

    public void CheckFalling() {
        justFalled = Physics2D.OverlapAreaAll(fallDetector.bounds.min, fallDetector.bounds.max, groundMask).Length > 0;

    }

}