using System;
using UnityEngine;

public class ArrowController : Singleton<ArrowController>
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    private QuestGoalController currentGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        meshRenderer.enabled = false;
    }

    public void SetActiveGoal(QuestGoalController questGoalController) {
        currentGoal = questGoalController;
        meshRenderer.enabled = true;
    }

    public void Reset() {
        currentGoal = null;
        meshRenderer.enabled = false;
    }

    void Update() {
        
        if(currentGoal == null) {
            return;
        }
        
        Vector3 targetLocation = currentGoal.transform.position;
        // targetLocation.y = transform.position.y;
        transform.LookAt(targetLocation);
    } 
}
