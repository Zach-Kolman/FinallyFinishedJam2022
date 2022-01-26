using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool CanBeSeen;
    private GameObject[] Lights;
    
    bool CalculateCanBeSeen(GameObject Light)
    {
        float LightRange = Light.GetComponent<Light>().range;
        if(Vector3.Distance(this.transform.position, Light.transform.position) < LightRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    bool ClearPathToLight(GameObject Light)
    {
       RaycastHit hit;
       float DistanceToLight = Vector3.Distance(this.transform.position, Light.transform.position);
       if(Physics.Raycast(this.transform.position, (Light.transform.position - this.transform.position), out hit, DistanceToLight))
       {
           return false;
       }
       return true;
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
        foreach(GameObject x in Lights)
        {
            bool PlayerInLight;
            if(CalculateCanBeSeen(x) && ClearPathToLight(x))
            {
                PlayerInLight = true;
            }
            else
            {
                PlayerInLight = false;
            }
            
            if(PlayerInLight)
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
        
    }
}
