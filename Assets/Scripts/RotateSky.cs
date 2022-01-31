using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_rotation", rotateSpeed * Time.deltaTime);
    }
}
