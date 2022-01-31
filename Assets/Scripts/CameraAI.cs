using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAI : MonoBehaviour
{
    public Renderer render;
    public Material cameraMaterialDetected;
    public UIManager uiManager;
    public RotateSecurityCamera rotateSecurityCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Caught");
            render.material = cameraMaterialDetected;
            rotateSecurityCamera.canRotate = false;
            this.gameObject.GetComponent<AudioSource>().Play();
            other.GetComponent<PlayerController>().enabled = false;
            uiManager.GameIsOver(false);
        }   
    }
}
