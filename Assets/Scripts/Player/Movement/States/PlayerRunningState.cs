using UnityEngine;

public class PlayerRunningState : PlayerMovementState
{
    private GroundCheck groundCheck;

    public PlayerRunningState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController, PlayerInputController playerInputController, GroundCheck groundCheck) : base(stateMachine, playerMovementController, playerInputController)
    {
        this.groundCheck = groundCheck;
    }

    public override void OnEnd()
    {
        MovementController.SetSprinting(false);
    }

    public override void OnStart()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
        MovementController.Move(InputController.GetCameraAdjustedInputVector().normalized);
        MovementController.SetSprinting(InputController.GetSprint());
        

        if(InputController.GetJump()) {
            MovementController.Jump();
            StateMachine.ChangeState(StateMachine.FallingState);
        }
    }

    public override void OnFixedUpdate(float fixedDeltaTime)
    {
        base.OnFixedUpdate(fixedDeltaTime);

        if(!groundCheck.OnGround()) {
            StateMachine.ChangeState(StateMachine.FallingState);
        }
    }
}
