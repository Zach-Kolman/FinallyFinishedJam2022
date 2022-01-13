using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCar : MonoBehaviour
{
    public Transform exitPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().exitPoint = exitPoint;
            other.GetComponent<PlayerController>().canExit = true;
        }
    }
}
