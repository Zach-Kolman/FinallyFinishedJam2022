using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool CanBeSeen;
    private GameObject[] Lights;

    private Vector3 HeadHeightVector;
    
    enum InLight {NO, YES};
    
    InLight CalculateCanBeSeen(GameObject myLight)
    {
        int layerMask = 1 << 6;
        layerMask = ~layerMask;
        float LightRange = myLight.GetComponent<Light>().range;
        if((Vector3.Distance(this.transform.position, myLight.transform.position) < LightRange) && myLight.GetComponent<Light>().enabled)
        {
            RaycastHit hit;
	        float DistanceToLight = Vector3.Distance(this.transform.position, myLight.transform.position);
	        if(Physics.Raycast(HeadHeightVector, (myLight.transform.position - this.transform.position), out hit, DistanceToLight, layerMask))
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
            Gizmos.DrawLine(HeadHeightVector, x.transform.position);
        }
    }
    #endif
    
    void Start()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
        HeadHeightVector = new Vector3(this.transform.position.x, this.transform.position.y + 2.0f, this.transform.position.z);
    }

    void LateUpdate()
    {
        HeadHeightVector = new Vector3(this.transform.position.x, this.transform.position.y + 2.0f, this.transform.position.z);
        foreach (GameObject x in Lights)
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
