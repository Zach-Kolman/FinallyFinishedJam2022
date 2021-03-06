using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSecurityCamera : MonoBehaviour
{

    private float xSpeed = 0.0f;
    public float rotateSpeed = 20.0f;
    private float zSpeed = 0.0f;

    private float yRotation = 0.0f;
    public float leftRotationLimit = 45.0f;
    public float rightRotationLimit = 45.0f;
    private float currentRotation = 0.0f;
    public bool canRotate = true;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.rotation.y;
        leftRotationLimit = currentRotation - leftRotationLimit;

    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (canRotate)
        {
            yRotation = rotateSpeed * Time.deltaTime;
            currentRotation += yRotation;
            
            if (currentRotation < leftRotationLimit)
            {
                currentRotation = leftRotationLimit;
                rotateSpeed *= -1.0f;
            }
            if (currentRotation >= rightRotationLimit)
            {
                currentRotation = rightRotationLimit;
                rotateSpeed *= -1.0f;
            }
            transform.Rotate(xSpeed * Time.deltaTime, yRotation, zSpeed * Time.deltaTime);
        }
    }
}
