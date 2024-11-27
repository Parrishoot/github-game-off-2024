using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    [SerializeField]
    private MenuButtonController menuButtonController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuButtonController.OnClick += StartGame;
    }

    private void StartGame()
    {
        SceneTransitionManager.Instance.OnTransitionOutFinished += () => SceneManager.LoadScene("MichaelScene");
        SceneTransitionManager.Instance.TransitionOut();
    }
}
