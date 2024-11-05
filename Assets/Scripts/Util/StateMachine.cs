using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set;}

    // Update is called once per frame
    protected virtual void Update()
    {
        CurrentState?.OnUpdate(Time.deltaTime);
    }

    protected void FixedUpdate() {
        CurrentState?.OnFixedUpdate(Time.fixedDeltaTime);    
    }

    public void ChangeState(IState newState) {
        CurrentState?.OnEnd();

        CurrentState = newState;
        newState.OnStart();
    }
}