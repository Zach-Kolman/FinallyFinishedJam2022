using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public bool DrawViewGizmo = false;
    public bool DrawGizmoToFirstWaypoint = false;
    public Animator EnemyAnimator;
    public Transform HeadJoint;
    public float ViewDistance = 0.0f;
    public float ViewAngle = 85.0f;
    public List<Waypoint> Waypoints;

    private float MinViewAngle = 0.1f;

    private int waypointIdx;
    private Waypoint currentWaypoint;

    private float waitTimer;
    private bool isWaiting;
    private NavMeshAgent EnemyAgent;
    private string walkAnimVar = "IsWalking";
    private string velocityAnimVar = "Velocity";

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(DrawViewGizmo && HeadJoint)
        {
            Gizmos.color = new Color(1.0f, 1.0f, 0.5f, 0.3f);
            Vector3 HeadPosition = new Vector3(HeadJoint.transform.position.x, HeadJoint.transform.position.y+0.15f, HeadJoint.transform.position.z);
            Matrix4x4 HeadPositionMatrix = Matrix4x4.TRS(HeadPosition, HeadJoint.transform.rotation, HeadJoint.transform.localScale);
            Matrix4x4 prevMatrix = Gizmos.matrix;
            Gizmos.matrix = HeadPositionMatrix;
            Gizmos.DrawFrustum(Vector3.zero, ViewAngle, ViewDistance, MinViewAngle, 1.0f);
            Gizmos.matrix = prevMatrix;
        }

        if(Waypoints.Count > 0)
        {
            if(DrawGizmoToFirstWaypoint && Waypoints.Count > 0 && Waypoints[0])
            {
                Gizmos.color = new Color(0.0f, 0.0f, 1.0f, 0.35f);
                Gizmos.DrawLine(this.transform.position, Waypoints[0].transform.position);
            }
            Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.35f);
            int idx = 1;
            foreach(Waypoint p in Waypoints)
            {
                if(idx < Waypoints.Count)
                {
                    Gizmos.DrawLine(p.transform.position, Waypoints[idx].transform.position);
                    idx++;
                }
            }
        }
    }
    #endif

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
