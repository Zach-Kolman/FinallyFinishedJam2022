using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCamGizmo : MonoBehaviour
{
    // Start is called before the first frame update
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(this.transform.position, 0.5f);
    }
#endif
}
