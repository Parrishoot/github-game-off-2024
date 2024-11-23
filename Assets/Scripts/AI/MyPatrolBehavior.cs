using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Couldn't get the stupid unity behavior patrol to go up so I had to make my own :(
public class MyPatrolBehavior : MonoBehaviour
{
    private const float DISTANCE_THRESHOLD = .01f;

    [SerializeField]
    private Transform agent;

    [SerializeField]
    private Transform waypointsParent;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float waitTime = 0f;

    private Timer waitTimer;

    private List<Transform> waypoints = new List<Transform>();

    private Vector3 targetPos;

    private int targetIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = waypointsParent.GetComponentsInChildren<Transform>()
            .Where(x => waypointsParent.transform != x.transform)
            .ToList();

        SetupNextTarget();
    }

    private void SetupNextTarget()
    {
        waitTimer = null;
        targetPos = waypoints[(targetIndex++) % waypoints.Count].position;
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer?.DecreaseTime(Time.deltaTime);

        // Check if we hit our next target
        if(Vector3.Distance(targetPos, agent.transform.position) <= DISTANCE_THRESHOLD && waitTimer == null) {

            if(waitTime != 0) {
                waitTimer = new Timer(waitTime);
                waitTimer.OnTimerFinished += SetupNextTarget;
            }
            else {
                SetupNextTarget();
            }

        }

        // Move towards target
        Vector3 frameTargetPos = (targetPos - agent.transform.position).normalized * speed * Time.deltaTime;
        agent.transform.position += frameTargetPos; 
    }
}
