using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    [SerializeField]
    private PlayerMovementController playerMovementController;

    [SerializeField]
    private GroundCheck groundCheck;

    public PlayerRunningState RunningState { get; private set; }

    public PlayerFallingState FallingState { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunningState = new PlayerRunningState(this, playerMovementController);
        FallingState = new PlayerFallingState(this, playerMovementController, groundCheck);

        ChangeState(RunningState);
    }
}
