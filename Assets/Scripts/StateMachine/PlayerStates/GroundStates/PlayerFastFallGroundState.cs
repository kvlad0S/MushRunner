using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastFallGroundState : State {

    //public event EventHandler OnFastFallEnd;
    //[SerializeField] float fastFallTimerMax = .1f;
    //private float fastFallTimer;

    public override void Enter() {
        //fastFallTimer = fastFallTimerMax;
        animator.Play(anim.name);
    }

    public override void Do(){
        //fastFallTimer -= Time.deltaTime;
        //if (fastFallTimer <= 0){
          //  OnFastFallEnd?.Invoke(this, EventArgs.Empty);
       // }

    }

}
