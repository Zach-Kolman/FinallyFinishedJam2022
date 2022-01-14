using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float timeToWaitBeforeMove;

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(this.transform.position, 0.5f);
    }
    #endif
}
