using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public PlayerStealth PlayerStealthComponent;
    public GameObject EyeIconGO;
    private Camera MainCamera;

    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(MainCamera.transform);
        if(PlayerStealthComponent.CanBeSeen)
        {
            EyeIconGO.SetActive(true);
        }
        else
        {
            EyeIconGO.SetActive(false);
        }
    }
}
