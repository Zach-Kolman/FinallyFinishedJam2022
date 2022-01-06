using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToCar : MonoBehaviour
{
    public Transform entryPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().enterPoint = entryPoint;
            other.GetComponent<PlayerController>().StartCoroutine("SetEnter");
        }
    }
}
