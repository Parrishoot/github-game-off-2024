using UnityEngine;

public class PlayerFallingState : PlayerMovementState
{
    private GroundCheck groundCheck;

    private bool leftGround = false;

    private bool leftWall = false;

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
        leftGround = false;
        leftWall = false;
    }

    public override void OnUpdate(float deltaTime)
    {
        MovementController.Move(InputController.GetCameraAdjustedInputVector().normalized);
        MovementController.SetSprinting(InputController.GetSprint());
    }

    public override void OnFixedUpdate(float fixedDeltaTime)
    {
        leftGround = leftGround || !groundCheck.OnGround();
        leftWall = leftWall || !CheckForWall().HasValue;

        if(leftGround && groundCheck.OnGround()) {
            StateMachine.ChangeState(StateMachine.RunningState);
        }

        if(leftWall && MovementController.IsFalling && CheckForWall().HasValue) {
            StateMachine.ChangeState(StateMachine.WallSlideState);
        }
    }
}
