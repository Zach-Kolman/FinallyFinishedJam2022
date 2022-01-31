using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public Light light;
    public UIManager uiManager;
    private bool isTriggering;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggering && Input.GetKeyDown(KeyCode.E))
        {
            light.enabled = !light.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Toggle switch with E");
            uiManager.ShowSwitchText();
            isTriggering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiManager.ShowSwitchText();
            isTriggering = false;
        }
    }
}
