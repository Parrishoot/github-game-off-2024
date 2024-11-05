using UnityEngine;

public class PlayerWallSlideState : PlayerMovementState
{
    private const float SLIDE_SPEED = 10f;

    private GroundCheck groundCheck;

    public PlayerWallSlideState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController, PlayerInputController playerInputController, GroundCheck groundCheck) : base(stateMachine, playerMovementController, playerInputController)
    {
        this.groundCheck = groundCheck;
    }

    public override void OnEnd()
    {
        
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate(float deltaTime)
    {
        if(InputController.GetJump()) {
            MovementController.WallJump(-InputController.GetCameraAdjustedInputVector().normalized);
            StateMachine.ChangeState(StateMachine.FallingState);
        }
    }

    public override void OnFixedUpdate(float fixedDeltaTime)
    {
        if(groundCheck.OnGround()) {
            StateMachine.ChangeState(StateMachine.RunningState);
        }
    }
}
