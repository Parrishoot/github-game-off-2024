using System;
using TMPro;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;

    [SerializeField]
    private float textSpeed = .1f;

    public Action OnStart;

    public Action OnFinish; 

    public Action OnLetterShown;

    private string currentLine;

    private int currentIndex = 0;

    private Timer textTimer;

    public void BeginAnimation(string line) {
        
        tmpText.text = "";
        currentLine = line;

        currentIndex = 0;

        CheckComplete();
        OnStart?.Invoke();
    }

    private void CheckComplete() {
        
        textTimer = new Timer(textSpeed);
        textTimer.OnTimerFinished += CheckComplete;

        if(currentIndex >= currentLine.Length) {
            textTimer = null;
            OnFinish?.Invoke();
            return;
        }

        tmpText.text += currentLine[currentIndex++];
        OnLetterShown?.Invoke();

        textTimer = new Timer(textSpeed);
        textTimer.OnTimerFinished += CheckComplete;
    }

    public void Update() {
        textTimer?.DecreaseTime(Time.deltaTime);
    }

}
