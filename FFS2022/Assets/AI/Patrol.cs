using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Animator EnemyAnimator;
    public List<Waypoint> Waypoints;

    private int waypointIdx;
    private Waypoint currentWaypoint;

    private float waitTimer;
    private bool isWaiting;
    private NavMeshAgent EnemyAgent;

    private string walkAnimVar = "IsWalking";
    private string velocityAnimVar = "Velocity";

    // Start is called before the first frame update
    void Start()
    {
        waypointIdx = 0;
        currentWaypoint = Waypoints[waypointIdx];
        this.EnemyAnimator.SetBool(walkAnimVar, true);
        EnemyAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if(waitTimer <= 0.0f)
            {
                isWaiting = false;
                MoveToNextWaypoint();
            }
        }
        else
        {
             EnemyAgent.SetDestination(currentWaypoint.transform.position);
             EnemyAnimator.SetFloat(velocityAnimVar, EnemyAgent.velocity.magnitude);
            if(Vector3.Distance(
                currentWaypoint.transform.position, this.transform.position) < EnemyAgent.stoppingDistance)
            {
                this.EnemyAnimator.SetBool(walkAnimVar, false);
                EnemyAgent.SetDestination(this.transform.position);
                isWaiting = true;
                waitTimer = currentWaypoint.timeToWaitBeforeMove;
            }
        }
    }

    void MoveToNextWaypoint()
    {
        waypointIdx++;
        if(waypointIdx > (Waypoints.Count-1))
        {
            waypointIdx = 0;
        }
        currentWaypoint = Waypoints[waypointIdx];
        this.EnemyAnimator.SetBool(walkAnimVar, true);
        EnemyAnimator.SetFloat(velocityAnimVar, EnemyAgent.velocity.magnitude);
    }
}
