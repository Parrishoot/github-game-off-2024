using UnityEngine;

public abstract class PlayerMovementState : GenericState<PlayerMovementStateMachine>
{
    private static float WALL_CHECK_RAYCAST_DISTANCE = 1f;

    protected PlayerMovementController MovementController { get; private set; }

    protected PlayerInputController InputController { get; private set; }

    protected bool LeftGround { get; private set; } = false;

    protected PlayerMovementState(PlayerMovementStateMachine stateMachine, PlayerMovementController playerMovementController, PlayerInputController playerInputController) : base(stateMachine)
    {
        this.MovementController = playerMovementController;
        this.InputController = playerInputController;
    }

    protected RaycastHit? CheckForWall() {

        // Check in the oppposite direction that you're moving
        RaycastHit hit;
        if(Physics.Raycast(StateMachine.transform.position, InputController.GetCameraAdjustedInputVector(), out hit,  WALL_CHECK_RAYCAST_DISTANCE, LayerMaskUtil.GetWallMask())) {
            return hit;
        }

        return null;
    }
}
