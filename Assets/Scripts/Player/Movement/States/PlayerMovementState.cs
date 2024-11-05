using UnityEngine;

public abstract class PlayerMovementState : GenericState<PlayerMovementStateMachine>
{
    protected PlayerMovementController MovementController { get; private set; }

    protected PlayerInputController InputController { get; private set; }

    protected PlayerMovementState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController) : base(stateMachine)
    {
        this.MovementController = playerMovementController;
        this.InputController = new PlayerInputController();
    }
}
