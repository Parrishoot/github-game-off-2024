using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    [SerializeField]
    private PlayerMovementController playerMovementController;

    [SerializeField]
    private GroundCheck groundCheck;

    [SerializeField]
    private PlayerInputController playerInputController;

    public PlayerRunningState RunningState { get; private set; }

    public PlayerFallingState FallingState { get; private set; }

    public PlayerWallSlideState WallSlideState { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunningState = new PlayerRunningState(this, playerMovementController, playerInputController, groundCheck);
        FallingState = new PlayerFallingState(this, playerMovementController, playerInputController, groundCheck);
        WallSlideState = new PlayerWallSlideState(this, playerMovementController, playerInputController, groundCheck);

        ChangeState(RunningState);
    }
}
