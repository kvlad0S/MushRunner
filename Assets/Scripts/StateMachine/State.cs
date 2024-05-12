using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class State : MonoBehaviour {


    public bool isComplete { get; protected set; }

    protected float startTime;
    
    protected Core core;
    [SerializeField] protected AnimationClip anim;
    public Animator animator => core.animator;
    public Rigidbody2D body => core.body;
    public bool isGrounded => core.groundSensor.isGrounded;

    public StateMachine machine;

    public StateMachine parent;

    public State state => machine.state;




 

    public float time => Time.time - startTime;

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }


    public void SetCore(Core _core) {
        machine = new StateMachine();
        core = _core;
    }

    public void Set(State newState, bool forceReset = false) {
        machine.Set(newState, forceReset);
    }

    public void DoBranch() {
        Do();
        state?.DoBranch();
    }

    public void FixedDoBranch() {
        FixedDo();
        state?.FixedDoBranch();
    }



    public void Initialize(StateMachine _parent) {
        parent = _parent;
        isComplete = false;
        startTime = Time.time;
        
    }


}

