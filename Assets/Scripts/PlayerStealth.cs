using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool CanBeSeen;
    private GameObject[] Lights;
    
    enum InLight {NO, YES};
    
    InLight CalculateCanBeSeen(GameObject Light)
    {
        float LightRange = Light.GetComponent<Light>().range;
        if(Vector3.Distance(this.transform.position, Light.transform.position) < LightRange)
        {
            RaycastHit hit;
	    float DistanceToLight = Vector3.Distance(this.transform.position, Light.transform.position);
	    if(Physics.Raycast(this.transform.position, (Light.transform.position - this.transform.position), out hit, DistanceToLight))
	    {
	        return InLight.NO;
	    }
	    return InLight.YES;
        }
        return InLight.NO;
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
        foreach(GameObject x in Lights)
        {
            InLight PlayerInLight = CalculateCanBeSeen(x);
            
            if(PlayerInLight == InLight.YES)
            {
                Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
            }
            else
            {
                Gizmos.color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
            }
            Gizmos.DrawLine(this.transform.position, x.transform.position);
        }
    }
    #endif
    
    void Start()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
    }

    void LateUpdate()
    {
        foreach(GameObject x in Lights)
        {
            InLight IsVisible = CalculateCanBeSeen(x);
            if(IsVisible == InLight.YES)
            {
                CanBeSeen = true;
                break;
            }
            CanBeSeen = false;
        }
    }
}
