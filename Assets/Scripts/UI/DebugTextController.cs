using TMPro;
using UnityEngine;

public class DebugTextController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private StateMachine stateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Player State: " + stateMachine.CurrentState.GetType().Name;
    }
}
