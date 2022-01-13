using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControls : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().controlsEnabled = true;
            gameObject.SetActive(false);
        }
    }
}
