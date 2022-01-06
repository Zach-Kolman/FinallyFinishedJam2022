using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerCamera;
    private CharacterController characterController;
    [SerializeField]
    public float moveSpeed = 100.0f;
    public float walkSpeed = 100.0f;
    public float runSpeed = 800.0f;

    [SerializeField]
    private float turnSpeed = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();    
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var m_horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        Vector3 camForward = PlayerCamera.transform.forward.normalized;
        Vector3 camRight = PlayerCamera.transform.right.normalized;

        var movement = camForward * vertical + camRight * horizontal;
        movement.y = 0; // No Y movement

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);
    }
}
