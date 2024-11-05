using UnityEngine;

public class PlayerFallingState : PlayerMovementState
{
    private GroundCheck groundCheck;

    public PlayerFallingState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController, GroundCheck groundCheck) : base(stateMachine, playerMovementController)
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
        MovementController.Move(InputController.GetMovementVector().normalized);
        MovementController.SetSprinting(InputController.GetSprint());

        if(MovementController.Rigidbody.linearVelocity.y < 0 && groundCheck.OnGround) {
            StateMachine.ChangeState(StateMachine.RunningState);
        }
    }
}
