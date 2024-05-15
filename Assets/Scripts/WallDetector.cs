using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour {

    [SerializeField] private BoxCollider2D leftCollider;
    [SerializeField] private BoxCollider2D rightCollider;
    [SerializeField] LayerMask groundMask;

    public bool isOnWall {get; private set;}

    public void FixedUpdate() {
        CheckWalls();
    }

    private void CheckWalls() {
        isOnWall = Physics2D.OverlapAreaAll(leftCollider.bounds.min, leftCollider.bounds.max, groundMask).Length > 0 || 
        Physics2D.OverlapAreaAll(rightCollider.bounds.min, rightCollider.bounds.max, groundMask).Length > 0;
    }

    public bool IsWallDirectionRight() {
        return Physics2D.OverlapAreaAll(leftCollider.bounds.min, leftCollider.bounds.max, groundMask).Length > 0;
    }


}

