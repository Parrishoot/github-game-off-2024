using UnityEngine;

public class PlayerFallingState : PlayerMovementState
{
    private GroundCheck groundCheck;

    public PlayerFallingState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController, PlayerInputController playerInputController, GroundCheck groundCheck) : base(stateMachine, playerMovementController, playerInputController)
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
    }

    public override void OnFixedUpdate(float fixedDeltaTime)
    {
        if(groundCheck.OnGround() && MovementController.Rigidbody.linearVelocity.y <= 0) {
            StateMachine.ChangeState(StateMachine.RunningState);
        }

        // if(leftWall && MovementController.IsFalling && CheckForWall().HasValue) {
        //     StateMachine.ChangeState(StateMachine.WallSlideState);
        // }
    }
}
