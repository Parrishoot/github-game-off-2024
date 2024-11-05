using UnityEngine;

public class PlayerRunningState : PlayerMovementState
{
    public PlayerRunningState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController) : base(stateMachine, playerMovementController)
    {
    }

    public override void OnEnd()
    {
    }

    public override void OnStart()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
        MovementController.Move(InputController.GetMovementVector());

        if(InputController.GetJump()) {
            MovementController.Jump();
            StateMachine.ChangeState(StateMachine.FallingState);
        }
    }
}
