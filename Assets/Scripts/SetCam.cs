using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCam : MonoBehaviour
{
    public CinemachineVirtualCamera curCam;
    public GameObject camManager;

    //set depth of all cameras to 10 minus 1;
    private IEnumerator OnTriggerEnter(Collider other)
    {
        GameObject cMan = camManager;
        if(other.gameObject.tag == "Player")
        {
            yield return new WaitForSeconds(0f);
            cMan.GetComponent<CamManager>().SwitchCamera();
            curCam.enabled = true;

            cMan.GetComponent<CamManager>().curCam = curCam;
        }
    }
}
